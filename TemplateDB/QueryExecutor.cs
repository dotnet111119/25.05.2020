using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateDB;

namespace TemplatePr
{
    public static class QueryExecutor
    {
        public static List<T> SelectAll<T>(string tableName = null) where T : new()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["employeedb"].ConnectionString);
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;

            if (tableName == null)
            {
                var customFieldAttributes = (MyTableNameAttribute[])typeof(T).GetCustomAttributes(typeof(MyTableNameAttribute), true);
                if (customFieldAttributes.Length > 0)
                {
                    tableName = customFieldAttributes[0].TableName;
                }
                else
                {
                    throw new MissingTableNameAttribute($"missing table name attribute of class {typeof(T).Name}");
                }
            }

            cmd.CommandText = $"SELECT * FROM {tableName}";

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            List<T> list = new List<T>();
            Type type_of_record = typeof(T);
            while (reader.Read() == true)
            {
                T one_record = new T();
                //T one_record = Activator.CreateInstance<T>();

                // short and sweet
                //type_of_record.GetProperties().ToList().ForEach(p => p.SetValue(one_record, reader[p.Name]));

                // longer way ...
                var all_prop = type_of_record.GetProperties();
                foreach (var oneProperty in type_of_record.GetProperties())
                {
                    var dbcolumn_prop = (MyDBColumnAttribute[])oneProperty.GetCustomAttributes(typeof(MyDBColumnAttribute), true);
                    if (dbcolumn_prop.Length > 0)
                    {
                        string columnname = oneProperty.Name;
                        if (dbcolumn_prop[0].MapToColumn != null)
                        {
                            columnname = dbcolumn_prop[0].MapToColumn;
                        }

                        var value = reader[columnname];
                        oneProperty.SetValue(one_record, value);

                    }
                    else
                    {
                        var default_attr_array =  (MyDefaultValueAttribute[])oneProperty.GetCustomAttributes(typeof(MyDefaultValueAttribute), true);
                        if (default_attr_array.Length > 0)
                        {
                            oneProperty.SetValue(one_record, default_attr_array[0].DefaultValue);
                        }
                    }


                }

                list.Add(one_record);
            }
            
            cmd.Connection.Close();

            return list;
        }
    }
}
