using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Rest_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/Employee/getAllEmployees/",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]

        List<Employee> getAllEmployees();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/Employee/getEmployees/{empId}",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]

        Employee GetEmployeesById(string empId);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Employee/UpdateEmployee/{EmployeeId}/{Salary}",
         BodyStyle = WebMessageBodyStyle.Wrapped,
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json)]

        string UpdateEmployee(string EmployeeId, string Salary);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/Employee/AddEmployee/{Id}/{Name}/{Salary}",
              BodyStyle = WebMessageBodyStyle.WrappedRequest,
             RequestFormat = WebMessageFormat.Json,
              ResponseFormat = WebMessageFormat.Json)]

        string Add(string Id, string Name, string Salary);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Employee/DeleteEmployee/{Id}",
              BodyStyle = WebMessageBodyStyle.WrappedRequest,
             RequestFormat = WebMessageFormat.Json,
              ResponseFormat = WebMessageFormat.Json)]

        string DeleteEmployee(string Id);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Employee
    {
        int id;
        string name;
        double salary;

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }
    }
}
