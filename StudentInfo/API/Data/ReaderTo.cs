using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using StudentInfo.API.Models;
using ServiceStack.Text;

namespace StudentInfo.API.Data
{
    /// <summary>
    /// Tool for converting a Sql Data Reader to an Object when the column and property names match. 
    /// Type filtered for objects that inherit from the DatabaseTable class
    /// </summary>
    /// <typeparam name="T">Any type that inherits from the Table class</typeparam>
    public class ReaderTo<T> where T : Table, new()
    {
        public static List<T> Convert(SqlDataReader reader)
        {

            var resultList = new List<T>();
            var colList = new List<string>();

            for (var i = 0; i < reader.FieldCount; i++)
            {
                colList.Add(reader.GetName(i));
            }

            while (reader.Read())
            {
                var item = new T();
                var t = item.GetType();

                foreach (var property in t.GetProperties().Where(x => colList.Contains(x.Name)))
                {
                    var type = property.PropertyType;
                    var readerValue = string.Empty;

                    if (reader[property.Name] != DBNull.Value)
                    {
                        readerValue = reader[property.Name].ToString();
                    }

                    if (string.IsNullOrEmpty(readerValue)) continue;

                    if (type.Name == "DateTime")
                    {
                        var date = new DateTime();
                        property.SetValue(item, DateTime.TryParse(readerValue, out date) ? date : DateTime.MinValue, null);
                    }
                    else
                    {
                        property.SetValue(item, readerValue.To(type), null);
                    }
                }
                resultList.Add(item);
            }

            return resultList;


        }
        public static List<T> Convert(SqlDataReader reader, Dictionary<string, string> customMapping)
        {

            var resultList = new List<T>();

            var item = new T();
            Type t = item.GetType();
            while (reader.Read())
            {
                foreach (PropertyInfo property in t.GetProperties())
                {
                    Type type = property.PropertyType;
                    string readerValue = string.Empty;

                    if (reader[property.Name] != DBNull.Value)
                    {
                        readerValue = reader[property.Name].ToString();
                    }

                    if (!string.IsNullOrEmpty(readerValue))
                    {
                        property.SetValue(item, readerValue.To(type), null);
                    }

                }
                resultList.Add(item);
            }

            return resultList;

        }
    }

}
