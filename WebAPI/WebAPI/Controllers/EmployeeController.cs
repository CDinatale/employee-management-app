using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        //get all employees
        public HttpResponseMessage Get()
        {
            string query = @"
                    select EmployeeId, EmployeeName, EmployeeAddress,
                    PhoneNumber, Position
                    from
                    dbo.Employee
                    ";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["EmployeeAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        //add employee
        public string Post(Employee employee)
        {
            try
            {
                string query = @"
                    insert into dbo.Employee values
                    (
                    '"+ employee.EmployeeName + @"',
                    '" + employee.EmployeeAddress + @"',
                    '" + employee.PhoneNumber + @"',
                    '" + employee.Position + @"'
                    )
                    ";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Employee added successfully.";
            }
            catch (Exception)
            {

                return "Failed to add employee.";
            }

        }

        //update employee
        public string Put(Employee employee)
        {
            try
            {
                string query = @"
                    update dbo.Employee set 
                    EmployeeName='" + employee.EmployeeName + @"',
                    EmployeeAddress='" + employee.EmployeeAddress + @"',
                    PhoneNumber='" + employee.PhoneNumber + @"',
                    Position='" + employee.Position + @"'
                    where EmployeeId=" + employee.EmployeeId + @"
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Employee updated successfully.";
            }
            catch (Exception)
            {

                return "Failed to update employee.";
            }
        }

        //delete employee
        public string Delete(int id)
        {
            try
            {
                string query = @"
                    delete from dbo.Employee 
                    where EmployeeId=" + id + @"
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Employee deleted successfully.";
            }
            catch (Exception)
            {

                return "Failed to delete employee.";
            }
        }
    }
}
