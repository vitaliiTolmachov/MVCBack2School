using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using _5_Input_OutputFormatters.Models;

namespace _5_Input_OutputFormatters.Formatters
{
    public class CustomInputFormatter :TextInputFormatter
    {
        public CustomInputFormatter()
        {
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);

            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/cu-for"));
        }

        protected override bool CanReadType(Type type)
        {
            if (type == typeof(Employee))
            {
                return base.CanReadType(type); 
            }
            return false;
        }

        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (encoding == null)
            {
                throw new ArgumentNullException(nameof(encoding));
            }

            var request = context.HttpContext.Request;
            using (var reader = new StreamReader(request.Body, encoding))
            {
                try
                {
                    var line = await reader.ReadLineAsync();

                    if (!line.StartsWith("BEGIN|VERSION:1"))
                    {
                        var errorMessage = $"Data must start with 'BEGIN|VERSION:1'";
                        context.ModelState.TryAddModelError(context.ModelName, errorMessage);
                        throw new Exception(errorMessage);
                    }
                    if (!line.EndsWith("|END"))
                    {
                        var errorMessage = $"Data must end with '|END'";
                        context.ModelState.TryAddModelError(context.ModelName, errorMessage);
                        throw new Exception(errorMessage);
                    }
                    var split = line.Substring(line.IndexOf("Data:") + 5).Split(new char[] { '|' });
                    var emp = new Employee()
                    {
                        Age = Convert.ToInt32(split[0].ToString()),
                        Code = split[1],
                        FirstName = split[2],
                        LastName = split[3]
                    };
                    return await InputFormatterResult.SuccessAsync(emp);
                }
                catch (Exception e)
                {
                    return await InputFormatterResult.FailureAsync();
                }
            }
        }
    }
}
