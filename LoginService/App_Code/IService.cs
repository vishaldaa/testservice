using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
    [ServiceContract]
    public interface IService
    {

        [OperationContract, WebInvoke(UriTemplate = "/login", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Login Login(Login login);

        //[OperationContract, WebGet(UriTemplate = "/GetLeaveType", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        //IEnumerable<Comman> GetLeaveType();

        [OperationContract, WebGet(UriTemplate = "/NewLogin/{usr}/{pwd}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        IEnumerable<Login> NewLogin(string usr,string pwd);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Login
    {

        [DataMember(Name = "citycode")]
        public string CityCode { get; set; }
        [DataMember(Name = "divcode")]
        public string PlantCode { get; set; }
        [DataMember(Name = "imei")]
        public string IMEI { get; set; }
        [DataMember(Name = "msgId")]
        public string MasgId { get; set; }
        [DataMember(Name = "message")]
        public string Message { get; set; }
        [DataMember(Name = "password")]
        public string Password { get; set; }
        [DataMember(Name = "statecode")]
        public string EmailId { get; set; }
        [DataMember(Name = "userid")]
        public string UserID { get; set; }
        [DataMember(Name = "username")]
        public string UserName { get; set; }
    }

    [DataContract]
    public class Comman
    {
        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "value")]
        public string Value { get; set; }

        [DataMember(Name = "tvalue")]
        public string Tvalue { get; set; }

        [DataMember(Name = "tarqty")]
        public string Tarqty { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }

    }
}
