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

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "InstallationCall" in code, svc and config file together.
namespace WcfService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class InstallationCall : IInstallationCall
    {
        public IEnumerable<Installation> InstallationCalls(string usr,string status)
        {
            using (SqlConnection connection = DataConnection.GetNewSqlConnection())
            {

                var cmd = new SqlCommand("InstallationCalls", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@userid", usr));
                cmd.Parameters.Add(new SqlParameter("@status", status));
                connection.Open();
                DataTable Dt= new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(Dt);
                if (Dt!=null && Dt.Rows.Count > 0 )
                {
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        var Call = new Installation
                        {
                            AssignmentId = Dt.Rows[i]["AssignmentId"].ToString(),
                            AssignmentDate = Dt.Rows[i]["doc_date"].ToString(),
                            CallStartTime = Dt.Rows[i]["start_time"].ToString(),
                            CallEndTime = Dt.Rows[i]["end_time"].ToString(),
                            Status = Dt.Rows[i]["status"].ToString(),
                            Message = "Success",
                        };
                        yield return Call;
                    }

                }
                else
                {
                    var Call = new Installation
                    {
                        Message = "Record Not Found",
                    };
                    yield return Call;
                }
            }
        }

        public IEnumerable<InstallationDetail> InstallationCallDetail(string Aid)
        {
            using (SqlConnection connection = DataConnection.GetNewSqlConnection())
            {

                var cmd = new SqlCommand("InstallationCallDetail", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Aid", Aid));
                connection.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var CallDetail = new InstallationDetail
                    {
                        
                        OnsiteNo = reader["onsiteNo"].ToString(),
                        CustomerName = reader["euName"].ToString(),
                        Address = reader["Add1"].ToString(),
                        City = reader["cityName"].ToString(),
                        State = reader["stateName"].ToString(),
                        Pin = reader["Pin"].ToString(),
                        MobileNo = reader["mobileNo"].ToString(),
                        Email = reader["email"].ToString(),
                        Message = "Success",
                        
                    };
                    yield return CallDetail;
                }
                else
                {
                    var CallDetail = new InstallationDetail
                    {
                        Message = "No Record Found",
                    };
                    yield return CallDetail;
                }
                reader.Close();
            }
        }

        public IEnumerable<Acceptance> InstallationAcceptance(string Aid, string Onsiten, string status)
        {
            using (SqlConnection connection = DataConnection.GetNewSqlConnection())
            {

                var cmd = new SqlCommand("InstallationAcceptance", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Aid", Aid));
                cmd.Parameters.Add(new SqlParameter("@Onsite", Onsiten));
                cmd.Parameters.Add(new SqlParameter("@status", status));
                connection.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var CallAcceptance = new Acceptance
                    {
                        Message = "Success",

                    };
                    yield return CallAcceptance;
                }
                else
                {
                    var CallAcceptance = new Acceptance
                    {
                        Message = "Status not updated",
                    };
                    yield return CallAcceptance;
                }
                reader.Close();
            }
        }

        public IEnumerable<Response> CallStart(string Onsiten, string usr)
        {
            using (SqlConnection connection = DataConnection.GetNewSqlConnection())
            {

                var cmd = new SqlCommand("InstallationAcceptance", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Onsite", Onsiten));
                cmd.Parameters.Add(new SqlParameter("@usr", usr));
                connection.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var Callstart = new Response
                    {
                        Message = "Success",

                    };
                    yield return Callstart;
                }
                else
                {
                    var Callstart = new Response
                    {
                        Message = "Fail",
                    };
                    yield return Callstart;
                }
                reader.Close();
            }
        }

        public ClosedCalls CloseCalls(ClosedCalls Call)
        {
            string Message = string.Empty;
            using (SqlConnection connection = DataConnection.GetNewSqlConnection())
            {

                ClosedCalls Obj= new ClosedCalls();
                var cmd = new SqlCommand("Installationcallclose", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Aid", Call.AssignmentId));
                cmd.Parameters.Add(new SqlParameter("@Onsite", Call.OnsiteNo));
                cmd.Parameters.Add(new SqlParameter("@message", Call.FeedBack));
                cmd.Parameters.Add(new SqlParameter("@signature", Call.Signature));
                cmd.Parameters.Add(new SqlParameter("@user", Call.User));
                cmd.Parameters.Add(new SqlParameter("@lat", Call.Latitude));
                cmd.Parameters.Add(new SqlParameter("@long", Call.Longitude));
                cmd.Parameters.Add(new SqlParameter("@callclose", Call.ClosingDateTime));
                cmd.Parameters.Add(new SqlParameter("@status", Call.Status));
                connection.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    Obj.Message = "Success";   
                }
                catch (Exception exception)
                {
                    Obj.Message = exception.Message;
                }
                finally
                {
                    connection.Close();
                }
                return Obj;
            }
        }
    }
}
