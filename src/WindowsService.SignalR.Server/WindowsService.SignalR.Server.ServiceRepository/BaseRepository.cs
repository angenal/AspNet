using SqlSugar;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService.SignalR.Server.ServiceRepository
{
    /// <summary>
    /// 模块 基础类
    /// </summary>
    public class BaseRepository
    {
        public BaseRepository()
        {
            var config = new ConnectionConfig()
            {
                DbType = DbType.Sqlite,
                IsAutoCloseConnection = true,
                ConnectionString = ConfigurationManager.ConnectionStrings[ConnectionString].ConnectionString,
            };
            config.ConfigureExternalServices.DataInfoCacheService = new HttpRuntimeCache();

            db = new SqlSugarClient(config);

            System.Diagnostics.Debug.WriteLine($"SqlSugarClient : {db.ContextID}");
        }

        /// <summary>
        /// 数据库连接字符串配置
        /// </summary>
        static readonly string ConnectionString = "SqliteConnectionString";

        /// <summary>
        /// 数据库访问
        /// </summary>
        protected SqlSugarClient db { get; private set; }

    }
}
