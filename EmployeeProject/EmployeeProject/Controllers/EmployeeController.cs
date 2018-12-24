using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeProject.Models;
using System.Threading.Tasks;


namespace EmployeeProject.Controllers
{
    public class EmployeeController : ApiController
    {


        public List<Employee> GetAllEmployee()
        {
            List<Employee> employees = DALController.GetEmployeeAsync();
       
            return employees;
        }

        public Employee GetEmployee(int id)
        {
            List<Employee> employees = DALController.GetEmployeeAsync();
            return employees.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
