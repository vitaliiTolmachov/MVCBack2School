using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _5_TypeConverter.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DateOfJoining { get; set; }
    }
}
