using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using _5_TypeConverter.Formatters;

namespace _5_TypeConverter.Models
{
    [TypeConverter(typeof(EmployeeFilterConverter))]
    public class EmployeeFilter
    {
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public DateTime? DOJ { get; set; }
    }
}
