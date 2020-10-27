using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Panda.Common;

namespace Panda.Core
{
    public class DataBaseConfig
    {
        public static string ConnectionString => InitConn();
        public static DataBaseType DBType = DataBaseType.SqlServer;


        private static string InitConn()
        {
            var dbTypeStr = AppConfigHelper.Configuration["DataBase:DbProviderName"];
            var connectString = AppConfigHelper.Configuration["DataBase:ConnectionString"];
            switch (dbTypeStr)
            {
                case "MySql":
                    DBType = DataBaseType.MySql;
                    break;
                case "SqlServer":
                    DBType = DataBaseType.SqlServer;
                    break;
                case "Oracle":
                    DBType = DataBaseType.Oracle;
                    break;
                case "Sqlite":
                    DBType = DataBaseType.Sqlite;
                    connectString = $"DataSource=" + Path.Combine(Environment.CurrentDirectory, connectString);
                    break;
            }
            return connectString;
        }
    }
    public enum DataBaseType
    {
        MySql,
        SqlServer,
        Sqlite,
        Oracle,
        PostgreSQL
    }
}
