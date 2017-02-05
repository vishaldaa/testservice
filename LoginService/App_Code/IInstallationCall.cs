using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IInstallationCall" in both code and config file together.
namespace WcfService
{
    [ServiceContract]
    public interface IInstallationCall
    {
        [OperationContract, WebGet(UriTemplate = "/installationCall/{usr}/{status}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        IEnumerable<Installation> InstallationCalls(string usr,string status);

        [OperationContract, WebGet(UriTemplate = "/installationCallDetail/{AId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        IEnumerable<InstallationDetail> InstallationCallDetail(string aid);

        [OperationContract, WebGet(UriTemplate = "/installationAcceptance/{AId}/{onsiteno}/{status}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        IEnumerable<Acceptance> InstallationAcceptance(string aid, string Onsiteno, string status);

        [OperationContract, WebGet(UriTemplate = "/callstart/{onsiteno}/{usr}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        IEnumerable<Response> CallStart(string Onsiteno, string usr);

        [OperationContract, WebInvoke(UriTemplate = "callclose", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ClosedCalls CloseCalls(ClosedCalls call);
    }
    [DataContract]
    public class Installation
    {

        [DataMember(Name = "AssignmentId")]
        public string AssignmentId { get; set; }
        [DataMember(Name = "AssignmentDate")]
        public string AssignmentDate { get; set; }
        [DataMember(Name = "CallStartTime")]
        public string CallStartTime { get; set; }
        [DataMember(Name = "CallEndTime")]
        public string CallEndTime { get; set; }
        [DataMember(Name = "Status")]
        public string Status { get; set; }
        [DataMember(Name = "Message")]
        public string Message { get; set; }

    }

    public class InstallationDetail
    {

        [DataMember(Name = "OnsiteNo")]
        public string OnsiteNo { get; set; }
        [DataMember(Name = "CustomerName")]
        public string CustomerName { get; set; }
        [DataMember(Name = "Address")]
        public string Address { get; set; }
        [DataMember(Name = "City")]
        public string City { get; set; }
        [DataMember(Name = "State")]
        public string State { get; set; }
        [DataMember(Name = "Pin")]
        public string Pin { get; set; }
        [DataMember(Name = "Mobile")]
        public string MobileNo { get; set; }
        [DataMember(Name = "Email")]
        public string Email { get; set; }
        [DataMember(Name = "Message")]
        public string Message { get; set; }

    }


    public class Acceptance
    {
        [DataMember(Name = "Message")]
        public string Message { get; set; }

    }

    public class ClosedCalls
    {

        [DataMember(Name = "AssignmentId")]
        public string AssignmentId { get; set; }
        [DataMember(Name = "OnsiteNo")]
        public string OnsiteNo { get; set; }
        [DataMember(Name = "FeedBack")]
        public string FeedBack { get; set; }
        [DataMember(Name = "Signature")]
        public string Signature { get; set; }
        [DataMember(Name = "User")]
        public string User { get; set; }
        [DataMember(Name = "Latitude")]
        public string Latitude { get; set; }
        [DataMember(Name = "Longitude")]
        public string Longitude { get; set; }
        [DataMember(Name = "ClosingDateTime")]
        public string ClosingDateTime { get; set; }
        [DataMember(Name = "Message")]
        public string Message { get; set; }
        [DataMember(Name = "Status")]
        public string Status { get; set; }
        
        
    }
    public class Response
    {
        [DataMember(Name = "Message")]
        public string Message { get; set; }
    }
}



 