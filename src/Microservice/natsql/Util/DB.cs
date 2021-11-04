using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace natsql.Util
{
    /// <summary>
    /// LiteDB v5.0.* Helper
    /// </summary>
    public class DB
    {
        public const string ConnectionString = @"natsql.quartz.job.db";

        public static T[] Query<T>(Expression<Func<T, bool>> predicate, int skip = 0, int limit = 5000)
        {
            // Open database (or create if doesn't exist)
            using (var db = new LiteDatabase(ConnectionString))
            {
                var t = db.GetCollection<T>(nameof(T));
                var results = t.Find(predicate, skip, limit);
                return results.ToArray();
            }
        }

        public static bool Exists<T>(Expression<Func<T, bool>> predicate)
        {
            using (var db = new LiteDatabase(ConnectionString))
            {
                var t = db.GetCollection<T>(nameof(T));
                return t.Exists(predicate);
            }
        }

        public static T FindOne<T>(Expression<Func<T, bool>> predicate)
        {
            using (var db = new LiteDatabase(ConnectionString))
            {
                var t = db.GetCollection<T>(nameof(T));
                return t.FindOne(predicate);
            }
        }

        public static T FindById<T>(BsonValue id)
        {
            using (var db = new LiteDatabase(ConnectionString))
            {
                var t = db.GetCollection<T>(nameof(T));
                return t.FindById(id);
            }
        }

        public static BsonValue Insert<T>(T model)
        {
            using (var db = new LiteDatabase(ConnectionString))
            {
                var t = db.GetCollection<T>(nameof(T));
                return t.Insert(model);
            }
        }

        public static int InsertBulk<T>(IEnumerable<T> entities, int batchSize = 5000)
        {
            using (var db = new LiteDatabase(ConnectionString))
            {
                var t = db.GetCollection<T>(nameof(T));
                return t.InsertBulk(entities, batchSize);
            }
        }

        public static int DeleteMany<T>(Expression<Func<T, bool>> predicate)
        {
            using (var db = new LiteDatabase(ConnectionString))
            {
                var t = db.GetCollection<T>(nameof(T));
                return t.DeleteMany(predicate);
            }
        }
    }
}
