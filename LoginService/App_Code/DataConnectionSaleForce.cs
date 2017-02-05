using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

/// <summary>
/// Summary description for DataConnectionSaleForce
/// </summary>
namespace WcfService
{
    public class DataConnectionSaleForce
    {
        public enum DBInstanceType { CreateNew, CheckExisting };
        static readonly string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["IntexSaleForce"].ConnectionString;
      
        static DataConnectionSaleForce DataCon = null;

        private SqlConnection _sqlConnection;

        public SqlConnection SqlConnection
        {
            get { return _sqlConnection; }
        }

        private DataConnectionSaleForce()
        {
            _sqlConnection = new SqlConnection(ConnectionString);
        }

        public static DataConnectionSaleForce GetDataConnection()
        {
            if (DataCon == null)
                DataCon = new DataConnectionSaleForce();
            return DataCon;
        }
        public static SqlConnection GetNewSqlConnection()
        {
            return GetNewSqlConnection("IntexSaleForce");
        }

        public static SqlConnection GetNewSqlConnection(string DB)
        {
            return DB == "IntexSaleForce" ? new SqlConnection(ConnectionString) : null;
        }
    }
}