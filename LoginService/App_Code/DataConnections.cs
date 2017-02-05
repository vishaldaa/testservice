using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

//using Cfi.Factory.Utility;

namespace Mobile.wcf.SqlHelper
{
    public enum DBInstanceType { CreateNew, CheckExisting };

    public class DataConnection
    {
        static readonly string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["IntexLive"].ConnectionString;
      
        static DataConnection DataCon = null;

        private SqlConnection _sqlConnection;

        public SqlConnection SqlConnection
        {
            get { return _sqlConnection; }
        }

        private DataConnection()
        {
            _sqlConnection = new SqlConnection(ConnectionString);
        }

        public static DataConnection GetDataConnection()
        {
            if (DataCon == null)
                DataCon = new DataConnection();
            return DataCon;
        }
        public static SqlConnection GetNewSqlConnection()
        {
            return GetNewSqlConnection("IntexLive");
        }

        public static SqlConnection GetNewSqlConnection(string DB)
        {
            return DB == "IntexLive" ? new SqlConnection(ConnectionString) : null;
        }
              
    }

}
