using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateDB
{

    [AttributeUsage(AttributeTargets.Property)]
    public class MyDBColumnAttribute : Attribute
    {
        public string MapToColumn { get; set; }

        public MyDBColumnAttribute() { }
    }
}
