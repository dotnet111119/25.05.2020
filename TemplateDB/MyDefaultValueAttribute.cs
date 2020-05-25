using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateDB
{

    [AttributeUsage(AttributeTargets.Property)]
    public class MyDefaultValueAttribute : Attribute
    {
        public string DefaultValue { get; set; }

        public MyDefaultValueAttribute(string defaultValue) { this.DefaultValue = defaultValue; }
    }
}
