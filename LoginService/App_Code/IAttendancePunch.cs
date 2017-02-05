using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAttendancePunch" in both code and config file together.

namespace WcfService
{
    [ServiceContract]
    public interface IAttendancePunch
    {
        [OperationContract, WebGet(UriTemplate = "/markin", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        IEnumerable<MarkIn> MarkIn();

        [OperationContract, WebGet(UriTemplate = "/remark", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        IEnumerable<Remark> Remark();

        [OperationContract, WebInvoke(UriTemplate = "attendancepunch", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string Attendance(Attendance call);
    }

    [DataContract]
    public class MarkIn
    {
        [DataMember(Name = "Id")]
        public string Id { get; set; }
        [DataMember(Name = "Status")]
        public string Name { get; set; }
        [DataMember(Name = "Message")]
        public string Message { get; set; } 
    }

    public class Remark
    {
        [DataMember(Name = "Id")]
        public string Id { get; set; }
        [DataMember(Name = "Status")]
        public string Name { get; set; }
        [DataMember(Name = "Message")]
        public string Message { get; set; }
    }

    public class Attendance
    {
        [DataMember(Name = "EmpCode")]
        public string EmpCode { get; set; }
        [DataMember(Name = "PunchTime")]
        public string PunchTime { get; set; }
        [DataMember(Name = "Type")]
        public string Type { get; set; }
        [DataMember(Name = "StatusId")]
        public string StatusId { get; set; }
        [DataMember(Name = "RemarkId")]
        public string RemarkId { get; set; }
        [DataMember(Name = "Latitude")]
        public string Latitude { get; set; }
        [DataMember(Name = "Longitude")]
        public string Longitude { get; set; }
        [DataMember(Name = "Address")]
        public string Address { get; set; }
        
    }
}
