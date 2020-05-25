using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TemplatePr
{
    class Program
    {

       
        static void Main(string[] args)
        {
            //var result = SelectAll("Employees");
            //result.ForEach(e => Console.WriteLine(e));

            List<Employee> employees = QueryExecutor.SelectAll<Employee>();
            employees.ForEach(e => Console.WriteLine(e));

            
        }
    }
}
