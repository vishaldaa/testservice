using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;
using System.Data.SqlClient;
using System.Data;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AttendancePunch" in code, svc and config file together.
namespace WcfService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AttendancePunch : IAttendancePunch
    {
        public IEnumerable<MarkIn> MarkIn()
        {
            using (SqlConnection connection = DataConnectionSaleForce.GetNewSqlConnection())
            {
                var cmd = new SqlCommand("MarkInstatus", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                DataTable Dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(Dt);
                if (Dt != null && Dt.Rows.Count > 0)
                {
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        var Call = new MarkIn
                        {
                            Id = Dt.Rows[i]["StatusId"].ToString(),
                            Name = Dt.Rows[i]["StatusDesc"].ToString(),
                            Message = "Success",
                        };
                        yield return Call;
                    }
                }
                else
                {
                    var Call = new MarkIn
                    {
                        Message = "Record Not Found",
                    };
                    yield return Call;
                }
            }
        }
        public IEnumerable<Remark> Remark()
        {
            using (SqlConnection connection = DataConnectionSaleForce.GetNewSqlConnection())
            {
                var cmd = new SqlCommand("ICP_Remark", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                DataTable Dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(Dt);
                if (Dt != null && Dt.Rows.Count > 0)
                {
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        var Call = new Remark
                        {
                            Id = Dt.Rows[i]["RemarkID"].ToString(),
                            Name = Dt.Rows[i]["Remark"].ToString(),
                            Message = "Success",
                        };
                        yield return Call;
                    }

                }
                else
                {
                    var Call = new Remark
                    {
                        Message = "Record Not Found",
                    };
                    yield return Call;
                }

            }
        }
        public string Attendance(Attendance Obj)
        {
            string Message = string.Empty;
            using (SqlConnection connection = DataConnectionSaleForce.GetNewSqlConnection())
            {
                var cmd = new SqlCommand("Attendanceinsert", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@EmpCode", Obj.EmpCode));
                cmd.Parameters.Add(new SqlParameter("@PunchTime", Obj.PunchTime));
                cmd.Parameters.Add(new SqlParameter("@Type", Obj.Type));
                cmd.Parameters.Add(new SqlParameter("@statusid", Obj.StatusId));
                cmd.Parameters.Add(new SqlParameter("@remarkId", Obj.RemarkId));
                cmd.Parameters.Add(new SqlParameter("@lat",Obj.Latitude));
                cmd.Parameters.Add(new SqlParameter("@long",Obj.Longitude));
                cmd.Parameters.Add(new SqlParameter("@address", Obj.Address));
                connection.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    Message = "Success";
                }
                catch (Exception exception)
                {
                    Message = exception.Message;
                }
                finally
                {
                    connection.Close();
                }
                return Message;
            }
        }
    }
}
