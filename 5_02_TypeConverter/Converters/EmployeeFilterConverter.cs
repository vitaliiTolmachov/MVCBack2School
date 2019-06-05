using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Reflection;

using _5_TypeConverter.Models;

namespace _5_TypeConverter.Formatters
{
    public class EmployeeFilterConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (typeof(string) == sourceType)
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var strVal = value as String;
            var model = new EmployeeFilter();

            if (string.IsNullOrEmpty(strVal))
                return model;

            string[] filters = strVal.Split(';');
            foreach (string keyValueFilter in filters)
            {
                var filterSplit = keyValueFilter.Split(':');
                var key = filterSplit[0];
                var val = filterSplit[1];
                SetPropertyForModel(model, key, val);
            }

            return model;
        }

        private void SetPropertyForModel(EmployeeFilter model, string key, string val)
        {
            PropertyInfo[] props = typeof(EmployeeFilter).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            PropertyInfo prop = props.Where(p => p.Name.Equals(key, StringComparison.CurrentCultureIgnoreCase) == true && p.CanWrite).FirstOrDefault();
            if(prop != null)
                prop.SetValue(model,val);
        }
    }
}
