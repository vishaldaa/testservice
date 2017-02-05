using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace Mobile.wcf.SqlHelper
{
    
    //public enum DBInstanceType { CreateNew, CheckExisting };

    public class IntexDataConnection
    {
        static readonly string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Intex"].ConnectionString;

        static IntexDataConnection DataCon = null;

        private SqlConnection _sqlConnection;

        public SqlConnection SqlConnection
        {
            get { return _sqlConnection; }
        }

        private IntexDataConnection()
        {
            _sqlConnection = new SqlConnection(ConnectionString);
        }

        public static IntexDataConnection GetDataConnection()
        {
            if (DataCon == null)
                DataCon = new IntexDataConnection();
            return DataCon;
        }
        public static SqlConnection GetNewSqlConnection()
        {
            return GetNewSqlConnection("Intex");
        }

        public static SqlConnection GetNewSqlConnection(string DB)
        {
            return DB == "Intex" ? new SqlConnection(ConnectionString) : null;
        }

    }
}