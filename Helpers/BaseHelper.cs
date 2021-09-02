using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace LibrarySystem.Helpers
{
    public static class BaseHelper
    {
        public static string GetDataBaseType()
        {
            string dataBaseConfig = ConfigurationManager.AppSettings["DataBaseType"].ToString();
            return dataBaseConfig;
        }

        public static string GetSqlServerConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["LibrarySqlServerConnectionString"].ConnectionString;
        }

        public static string GetSQLiteConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["LibrarySQLiteConnectionString"].ConnectionString;
        }
    }
}