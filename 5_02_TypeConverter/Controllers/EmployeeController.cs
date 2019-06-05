using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _5_TypeConverter.Models;

namespace _5_TypeConverter.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> _empDb = new List<Employee>()
        {
            new Employee()
            {
                Id = 1,
                City = "Delhi",
                DateOfJoining = DateTime.Now.AddDays(-2),
                DOB = DateTime.Now.AddYears(-20),
                FirstName = "Nikhil",
                LastName = "Doomra",
                State = "Delhi",
                StreetAddress = "Street Address",
                ZipCode = "110011"
            },
            new Employee()
            {
                Id = 2,
                City = "Delhi",
                DateOfJoining = DateTime.Now.AddDays(-30),
                DOB = DateTime.Now.AddYears(-22),
                FirstName = "Vivek",
                LastName = "Sharma",
                State = "Delhi",
                StreetAddress = "Street Address",
                ZipCode = "110022"
            },
            new Employee()
            {
                Id = 1,
                City = "Delhi",
                DateOfJoining = DateTime.Now.AddDays(-28),
                DOB = DateTime.Now.AddYears(-28),
                FirstName = "Nikhil",
                LastName = "Gupta",
                State = "Delhi",
                StreetAddress = "Street Address",
                ZipCode = "110006"
            }
        };
        // GET api/values
        [HttpGet]
        public List<Employee> Get(string zipCode = "",
                                  string street = "",
                                  string firstName = "",
                                  string lastName = "",
                                  string city = "",
                                  string state = "",
                                  DateTime? doj = null)
        {
            return (from emp in _empDb
                    where
                        (!string.IsNullOrEmpty(firstName) ? emp.FirstName.StartsWith(firstName, StringComparison.CurrentCultureIgnoreCase) : true)
                        && (!string.IsNullOrEmpty(lastName) ? emp.LastName.StartsWith(lastName, StringComparison.CurrentCultureIgnoreCase) : true)
                        && (!string.IsNullOrEmpty(state) ? emp.State.StartsWith(state, StringComparison.CurrentCultureIgnoreCase) : true)
                        && (!string.IsNullOrEmpty(city) ? emp.City.StartsWith(city, StringComparison.CurrentCultureIgnoreCase) : true)
                        && (doj.HasValue ? emp.DateOfJoining >= doj.Value : true)
                    select emp
                ).ToList();
        }
        [HttpGet]
        public List<Employee> GetByFilter(EmployeeFilter filter)
        {
            return (from emp in _empDb
                    where
                        (!string.IsNullOrEmpty(filter.FirstName) ? emp.FirstName.StartsWith(filter.FirstName, StringComparison.CurrentCultureIgnoreCase) : true)
                        && (!string.IsNullOrEmpty(filter.LastName) ? emp.LastName.StartsWith(filter.LastName, StringComparison.CurrentCultureIgnoreCase) : true)
                        && (!string.IsNullOrEmpty(filter.State) ? emp.State.StartsWith(filter.State, StringComparison.CurrentCultureIgnoreCase) : true)
                        && (!string.IsNullOrEmpty(filter.City) ? emp.City.StartsWith(filter.City, StringComparison.CurrentCultureIgnoreCase) : true)
                        && (filter.DOJ.HasValue ? emp.DateOfJoining >= filter.DOJ : true)
                    select emp
                ).ToList();
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Employee> Post([FromBody] Employee value)
        {
            return Ok(value);
        }
    }
}
