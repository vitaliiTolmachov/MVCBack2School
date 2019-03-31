using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _5_Input_OutputFormatters.Models;

namespace _5_Input_OutputFormatters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            return new[]
            {
                new Employee { Age = 25, Code = "Marketing", FirstName = "Alex", LastName = "Brown" },
                new Employee { Age = 32, Code = "Sales", FirstName = "Lincey", LastName = "McRay" }
            };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            return new Employee { Age = 26, Code = "CTO", FirstName = "Steve", LastName = "Nelson" };
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Employee> Post([FromBody] Employee value)
        {
            return Ok(value);
        }
    }
}
