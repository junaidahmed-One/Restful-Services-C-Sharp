using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Rest_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public List<Employee> getAllEmployees()
        {
            List<Employee> emp = new List<Employee>();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\91879\source\repos\Rest_WCF\App_Data\Database1.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT * from Employee", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Employee obj = new Employee();
                    obj.Id = reader.GetInt32(0);
                    obj.Name = reader.GetString(1);
                    obj.Salary = reader.GetDouble(2);
                    emp.Add(obj);
                }

            }
            else
            {
                //No rows
            }

            reader.Close();
            return emp;
        }

        public Employee GetEmployeesById(string empId)
        {
            Employee obj1 = new Employee();
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\91879\source\repos\Rest_WCF\App_Data\Database1.mdf;Integrated Security=True");
            SqlCommand comd = new SqlCommand("SELECT Id,Name,Salary FROM Employee " +
                "WHERE Id=" +
                Convert.ToInt32(empId) +
                ";", conn);

            conn.Open();
            SqlDataReader reader = comd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    obj1.Id = reader.GetInt32(0);
                    obj1.Name = reader.GetString(1);
                    obj1.Salary = reader.GetDouble(2);
                }
            }
            else
            {
                // No rows found
            }
            reader.Close();
            return obj1;
        }

        public string UpdateEmployee(string EmployeeId, string Salary)
        {
            SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\91879\source\repos\Rest_WCF\App_Data\Database1.mdf;Integrated Security=True");
            
            SqlCommand cmd = con1.CreateCommand();

            cmd.CommandText = "Update Employee SET Salary='" + Convert.ToDouble(Salary)
            + "' WHERE Id=" + Convert.ToInt32(EmployeeId);

            con1.Open();

            cmd.ExecuteNonQuery();

            con1.Close();

            return "Updated Successfully";
        }

        public string Add(string Id, string Name, string Salary)
        {
            SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\91879\source\repos\Rest_WCF\App_Data\Database1.mdf;Integrated Security=True");
            
            cnn.Open();

            string query = "INSERT into Employee(Id,Name,Salary) values ('" + Convert.ToInt32(Id) + "', '" + Name + "', '" + Convert.ToDouble(Salary) + "')";
            
            SqlCommand cmd = new SqlCommand(query, cnn);

            cmd.ExecuteNonQuery();

            cnn.Close();

            return "Successful";
        }

        public string DeleteEmployee(string Id)
        {
            SqlConnection scon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\91879\source\repos\Rest_WCF\App_Data\Database1.mdf;Integrated Security=True");

            scon.Open();

            string delQuery = "DELETE FROM Employee where Id=" + Convert.ToInt32(Id);

            SqlCommand scmd = new SqlCommand(delQuery, scon);

            scmd.ExecuteNonQuery();

            scon.Close();

            return "Deleted Successfully";
        }
    }
}
