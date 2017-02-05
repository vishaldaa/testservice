using System;
using System.Data;
using System.Text;
using System.Globalization;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel.Activation;
using System.Data.SqlClient;
using Mobile.wcf.SqlHelper;

using System.ServiceModel.Web;
using System.ComponentModel;

using System.IO;

using System.Net;
using System.Xml;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
namespace WcfService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service : IService
    {
        public IEnumerable<Login> NewLogin(string usr, string pwd)
        {
            using (SqlConnection connection = DataConnection.GetNewSqlConnection())
            {
                var cmd = new SqlCommand("spLogin", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@userid", usr));
                cmd.Parameters.Add(new SqlParameter("@password", pwd));
                connection.Open();
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    var User = new Login
                    {
                        PlantCode = reader["plcode"].ToString(),
                        UserName = reader["Username"].ToString(),
                        Message = "Success"
                    };
                    yield return User;

                }
                else
                {
                    var User = new Login
                    {
                        Message = "Fail",
                    };
                    yield return User;
                
                }
                reader.Close();
            }
        }

        public Login Login(Login login)
        {
            using (SqlConnection connection = DataConnection.GetNewSqlConnection())
            {
                try
                {

                    // string result = null;
                    Login obj = new Login();
                    //HttpContext.Current.Session["UCode"] = login.UserID;
                    var cmd = new SqlCommand("spLogin", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@userid", login.UserID));
                    cmd.Parameters.Add(new SqlParameter("@password", login.Password));
                    //cmd.Parameters.Add(new SqlParameter("@imei", login.IMEI));
                    connection.Open();
                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        obj.PlantCode = reader["plcode"].ToString();
                        obj.UserName = reader["Username"].ToString();

                    }
                    //get Notifications

                    return obj;

                }
                catch (Exception exception)
                {
                    throw new Exception(exception.Message);
                }
                finally
                {
                    connection.Close();
                }

            }
        }
    }
}
