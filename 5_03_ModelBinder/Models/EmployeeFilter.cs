using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace _5_03_ModelBinder.Models
{
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

    public class EmployeeFilterModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            EmployeeFilter employeeFilter = new EmployeeFilter();
            SetPropertyValues(employeeFilter, bindingContext);
            bindingContext.Result = ModelBindingResult.Success(employeeFilter);
            return Task.CompletedTask;
        }

        private void SetPropertyValues(EmployeeFilter employeeFilter, ModelBindingContext bindingContext)
        {
            var properties = employeeFilter.GetType()
                                           .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                           .Where(p => p.CanWrite);

            foreach (PropertyInfo propertyInfo in properties)
            {
                var attemptedValue = bindingContext.ValueProvider.GetValue(propertyInfo.Name).FirstValue;
                if (!string.IsNullOrEmpty(attemptedValue))
                {
                    var propType = propertyInfo.PropertyType;
                    var converter = TypeDescriptor.GetConverter(propType);

                    propertyInfo.SetValue(employeeFilter, converter.ConvertFromString(attemptedValue));
                    propertyInfo.SetValue(employeeFilter, attemptedValue);
                }
            }
        }
    }
}
