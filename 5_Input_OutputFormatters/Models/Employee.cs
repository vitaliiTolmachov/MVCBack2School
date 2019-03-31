using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _5_Input_OutputFormatters.Models
{
    public interface IVersionable
    {
        int Version { get; }
    }
    public abstract class User : IVersionable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public abstract int Version { get; set; }
    }

    public class Employee : User
    {
        public int Age { get; set; }
        public string Code { get; set; }
        public override int Version { get; set; } = 1;
    }
}
