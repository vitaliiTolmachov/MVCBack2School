using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using _5_Input_OutputFormatters.Models;

namespace _5_Input_OutputFormatters.Formatters
{
    public class CustomOutputFormatter :TextOutputFormatter
    {
        public CustomOutputFormatter()
        {
            this.SupportedEncodings.Add(Encoding.UTF8);
            this.SupportedEncodings.Add(Encoding.Unicode);
            this.SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/cu-for"));
        }
        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            throw new NotImplementedException();
        }

        protected override bool CanWriteType(Type type)
        {
            if (typeof(Employee).IsAssignableFrom(type) ||
                typeof(IEnumerable<Employee>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }

            return false;
        }

        public override Task WriteAsync(OutputFormatterWriteContext context)
        {
            IServiceProvider serviceProvider = context.HttpContext.RequestServices;
            var response = context.HttpContext.Response;
            var sb = new StringBuilder();
            if (context.Object is IEnumerable<Employee>)
            {
                foreach (var employee in context.Object as IEnumerable<Employee>)
                {
                    FormatData(sb, employee);
                }
            }
            else
            {
                var employee = context.Object as Employee;
                FormatData(sb, employee);
            }
            return response.WriteAsync(sb.ToString());

        }

        private void FormatData(StringBuilder sb, Employee employee)
        {
            sb.Append("BEGIN|");
            sb.AppendFormat($"VERSION:{employee.Version}|");
            sb.AppendFormat($"Data:{employee.Age}|{employee.Code}|{employee.FirstName}|{employee.LastName}");
            sb.Append("|END");
        }
    }
}
