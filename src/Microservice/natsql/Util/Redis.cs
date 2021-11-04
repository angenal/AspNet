using Newtonsoft.Json;
using StackExchange.Redis;
using System;

namespace natsql.Util
{
    public class Redis
    {
        /// <summary>
        /// Redis database
        /// </summary>
        private const int DataBase = -1;

        /// <summary>
        /// The Redis configuration string
        /// </summary>
        private static string _configuration = null;

        /// <summary>
        /// Get the Redis connection multiplexer once
        /// </summary>
        private static readonly Lazy<IConnectionMultiplexer> redis = new Lazy<IConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(_configuration));

        private static bool inited = false;

        public static int DefaultExpirationSeconds = 0;

        public static void Init(RedisConfig config, int defaultExpirationSeconds = 3600)
        {
            if (_configuration != null || inited) return;

            _configuration = new LazyCache.RedisConfiguration(config.Addr) { Password = config.Password, DefaultDatabase = config.Db }.ToString();

            DefaultExpirationSeconds = defaultExpirationSeconds;
        }

        public static void Configure(Action<string> action)
        {
            if (_configuration == null || inited) return;

            action.Invoke(_configuration);

            inited = true;
        }

        public class List
        {
            /// <summary>
            /// Redis db instance
            /// </summary>
            readonly IDatabase Db;

            public List(string configuration = null)
            {
                Db = string.IsNullOrEmpty(configuration) ? redis.Value.GetDatabase(DataBase) : ConnectionMultiplexer.Connect(configuration).GetDatabase();
            }

            public string Get(string key)
            {
                var redisKey = new RedisKey(key);
                var redisVal = Db.StringGet(redisKey);
                return redisVal.HasValue ? redisVal.ToString() : null;
            }

            public bool Set(string key, string value, int expire)
            {
                var redisKey = new RedisKey(key);
                return Db.StringSet(redisKey, new RedisValue(value), expire > 0 ? TimeSpan.FromSeconds(expire) : (TimeSpan?)null);
            }

            public long Push(string key, string value, int expire)
            {
                var redisKey = new RedisKey(key);
                var i = Db.ListRightPush(redisKey, new RedisValue(value));
                if (expire > 0) Db.KeyExpire(redisKey, TimeSpan.FromSeconds(expire));
                return i;
            }

            public long Push<T>(string key, T value, int expire)
            {
                var redisKey = new RedisKey(key);
                var i = Db.ListRightPush(redisKey, new RedisValue(JsonConvert.SerializeObject(value, V8Script.Extensions.JsonConverters)));
                if (expire > 0) Db.KeyExpire(redisKey, TimeSpan.FromSeconds(expire));
                return i;
            }

            public long Push<T>(string key, T[] value)
            {
                var l = value.Length;
                if (l == 0) return 0;

                var values = new RedisValue[l];
                for (var i = 0; i < l; i++) values.SetValue(new RedisValue(JsonConvert.SerializeObject(value[i], V8Script.Extensions.JsonConverters)), i);

                var redisKey = new RedisKey(key);
                return Db.ListRightPush(redisKey, values);
            }

            public System.Collections.Generic.List<T> Pop<T>(string key, int size = 200)
            {
                var list = new System.Collections.Generic.List<T>();
                if (size <= 0) return list;

                try
                {
                    var redisKey = new RedisKey(key);
                    var redisVal = Db.ListLeftPop(redisKey);

                    while (redisVal.HasValue && size > 0)
                    {
                        if (!redisVal.IsNullOrEmpty)
                        {
                            T item = JsonConvert.DeserializeObject<T>(redisVal.ToString());
                            list.Add(item);
                        }

                        redisVal = Db.ListLeftPop(redisKey);
                        size--;
                    }
                }
                catch (Exception) { }
                return list;
            }

            public System.Collections.Generic.List<string> Pop(string key, int size = 200)
            {
                var list = new System.Collections.Generic.List<string>();
                if (size <= 0) return list;

                try
                {
                    var redisKey = new RedisKey(key);
                    var redisVal = Db.ListLeftPop(redisKey);

                    while (redisVal.HasValue && size > 0)
                    {
                        if (!redisVal.IsNullOrEmpty)
                        {
                            list.Add(redisVal.ToString());
                        }

                        redisVal = Db.ListLeftPop(redisKey);
                        size--;
                    }
                }
                catch (Exception) { }
                return list;
            }

            public bool Expire(string key, int expire)
            {
                var redisKey = new RedisKey(key);
                if (expire > 0) return Db.KeyExpire(redisKey, TimeSpan.FromSeconds(expire));
                return Db.KeyExpire(redisKey, (TimeSpan?)null);
            }

            public TimeSpan? Expire(string key)
            {
                var redisKey = new RedisKey(key);
                return Db.KeyTimeToLive(redisKey);
            }

            public TimeSpan? Idle(string key)
            {
                var redisKey = new RedisKey(key);
                return Db.KeyIdleTime(redisKey);
            }

            public bool Delete(string key)
            {
                return Db.KeyDelete(new RedisKey(key));
            }
        }

    }
}
