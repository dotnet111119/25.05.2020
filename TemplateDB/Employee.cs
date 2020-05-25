using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateDB;

namespace TemplatePr
{
    [MyTableName("Employees")]
    public class Employee
    {
        public void foo()
        {

        }
        public Employee()
        {

        }
        public Employee(int id)
        {

        }
        [MyDBColumn]
        public int Id { get; set; }
        [MyDBColumn(MapToColumn = "FirstName")]
        public string first { get; set; }
        [MyDBColumn]
        public string LastName { get; set; }
        [MyDBColumn]
        public string Gender { get; set; }
        [MyDBColumn]
        public int Salary { get; set; }

        public int my_number { get; set; }

        [MyDefaultValue("Tel aviv")]
        public string homeAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
