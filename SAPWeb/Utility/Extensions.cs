using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace SAPWeb.Utility
{
    public static class Extensions
    {
        //ashwin add
        public static string ToThousandNoDecimal(this decimal value)
        {
            return Math.Round(value, 0).ToString("###0");
        }
        /// <summary>
        /// Convert datatable to list of model.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static List<T> ConvertToList<T>(this DataTable dataTable)
        {
            try
            {
                List<string> columns = dataTable.Columns.Cast<DataColumn>().Select(c => c.ColumnName.ToLower()).ToList();
                PropertyInfo[] properties = typeof(T).GetProperties();
                return dataTable.AsEnumerable().Select(r =>
                {
                    T instance = Activator.CreateInstance<T>();
                    foreach (PropertyInfo propertyInfo in properties)
                    {
                        if (columns.Contains(propertyInfo.Name.ToLower())
                            && !Convert.IsDBNull(r[propertyInfo.Name]))
                        {
                            if (dataTable.Columns[propertyInfo.Name].DataType.Name == DbType.Date.ToString()
                                || dataTable.Columns[propertyInfo.Name].DataType.Name == DbType.DateTime.ToString())
                                propertyInfo.SetValue(instance, Convert.ToString(r[propertyInfo.Name]));
                            else
                                propertyInfo.SetValue(instance, Convert.ChangeType(r[propertyInfo.Name], propertyInfo.PropertyType));
                        }
                    }
                    return instance;
                }).ToList<T>();
            }
            catch (Exception ex)
            {
                // Log.WriteErrorLog(ex);
                throw;
            }
        }
        /// <summary>
        /// Convert datatable to single model.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static T ConvertToModel<T>(this DataTable dataTable)
        {
            try
            {
                if (dataTable != null)
                {
                    List<string> columns = dataTable.Columns.Cast<DataColumn>().Select(c => c.ColumnName.ToLower()).ToList();
                    PropertyInfo[] properties = typeof(T).GetProperties();
                    return dataTable.AsEnumerable().Select(r =>
                    {
                        T instance = Activator.CreateInstance<T>();
                        foreach (PropertyInfo propertyInfo in properties)
                        {
                            if (columns.Contains(propertyInfo.Name.ToLower()) && !Convert.IsDBNull(r[propertyInfo.Name]))
                            {
                                if (dataTable.Columns[propertyInfo.Name].DataType.Name == DbType.Date.ToString())
                                    propertyInfo.SetValue(instance, Convert.ToDateTime(r[propertyInfo.Name]).ToString("dd/MM/yyyy"));
                                else if (dataTable.Columns[propertyInfo.Name].DataType.Name == DbType.DateTime.ToString())
                                    propertyInfo.SetValue(instance, Convert.ToDateTime(r[propertyInfo.Name]).ToString("dd/MM/yyyy HH:mm:ss"));
                                else
                                    //propertyInfo.SetValue(instance, r[propertyInfo.Name]);
                                    propertyInfo.SetValue(instance, Convert.ChangeType(r[propertyInfo.Name], propertyInfo.PropertyType));
                            }
                        }
                        return instance;
                    }).FirstOrDefault<T>();
                }
                else
                {
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                //Log.WriteErrorLog(ex);

            }
            return default(T);
        }
        /// <summary>
        /// Convert list to datatable.
        /// </summary>
        /// <typeparam name="T">Generics typ parameter for convert from specified model.</typeparam>
        /// <param name="items">List of type parameter for convert to specified list.</param>
        /// <returns>specified model</returns>
        public static DataTable ConvertToTable<T>(this List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            try
            {

                PropertyInfo[] properties = typeof(T).GetProperties();
                foreach (PropertyInfo propertyInfo in properties)
                {
                    dataTable.Columns.Add(propertyInfo.Name, propertyInfo.PropertyType);
                }
                foreach (T item in items)
                {
                    var values = new object[properties.Length];
                    for (int i = 0; i < properties.Length; i++)
                    {
                        values[i] = properties[i].GetValue(item, null);
                    }
                    dataTable.Rows.Add(values);
                }

            }
            catch (Exception ex)
            {
                //Log.WriteErrorLog(ex);
            }
            return dataTable;
        }
        /// <summary>
        /// Convert to dictionary
        /// </summary>
        /// <param name="dataRow">DataRow type parameter for convert to dictionary.</param>
        /// <returns>List of dictionary</returns>
        public static List<IDictionary> ConvertToDictionary(this DataRow dataRow)
        {
            List<IDictionary> dictionaries = new List<IDictionary>();
            try
            {
                var dictionaryList = dataRow.Table.Columns.Cast<DataColumn>()
                    .Select(column =>
                      new {
                          Column = column.ColumnName,
                          Value = CheckDBValue(dataRow[column], column.DataType)
                      }).ToDictionary(c => c.Column, c => c.Value);

                dictionaries.Add(dictionaryList);

            }
            catch (Exception ex)
            {
                //Log.WriteErrorLog(ex);
            }
            return dictionaries;
        }
        /// <summary>
        /// Check DBNull value
        /// </summary>
        /// <param name="obj">object type paramter for value.</param>
        /// <param name="type">Type parameter for specified type.</param>
        /// <returns></returns>
        private static object CheckDBValue(object obj, Type type)
        {
            try
            {
                object value = obj;
                if (Convert.IsDBNull(obj))
                {
                    switch (type.Name)
                    {
                        case "String":
                        case "DateTime":
                        case "Date":
                            value = string.Empty;
                            break;
                        case "Int32":
                        case "Int16":
                        case "Decimal":
                        case "Double":
                            value = 0;
                            break;
                    }
                    return value;
                }

                switch (type.Name)
                {
                    case "DateTime":
                        value = Convert.ToDateTime(value).ToString("dd/MM/yyyy HH:mm:ss");
                        break;
                    case "Date":
                        value = Convert.ToDateTime(value).ToString("dd/MM/yyyy");
                        break;
                }
                return value;
            }
            catch (Exception ex)
            {
                //Log.WriteErrorLog(ex);
                throw;
            }
        }
    }
}