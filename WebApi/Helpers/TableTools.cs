using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System;
using System.Linq;

namespace WebApi.Helpers
{
    public static class TableTools
    {
        public static object DataTableToJSON(this DataTable table)
        {
            var list = new List<Dictionary<string, object>>();

            foreach (DataRow row in table.Rows)
            {
                var dict = new Dictionary<string, object>();

                foreach (DataColumn col in table.Columns)
                {
                    //dict[col.ColumnName] = (Convert.ToString(row[col]));
                    if (row[col].ToString().Trim() == String.Empty)
                    {
                        dict[col.ColumnName] = null;
                    }
                    else
                    {
                        dict[col.ColumnName] = row[col];
                    }

                }
                list.Add(dict);
            }
            if (list.Count == 1)
            {
                var ent = list[0];
                return ent;
            }

            return list;
        }
        public static object DataTableToJSONList(this DataTable table)
        {
            var list = new List<Dictionary<string, object>>();

            foreach (DataRow row in table.Rows)
            {
                var dict = new Dictionary<string, object>();

                foreach (DataColumn col in table.Columns)
                {
                    //dict[col.ColumnName] = (Convert.ToString(row[col]));
                    if (row[col].ToString().Trim() == String.Empty)
                    {
                        dict[col.ColumnName] = null;
                    }
                    else
                    {
                        dict[col.ColumnName] = row[col];
                    }

                }
                list.Add(dict);
            }


            return list;
        }
        #region Convertir Tabla en Listas
        public static List<T> TableTolist<T>(this DataTable datatable) where T : new()
        {
            List<T> Temp = new List<T>();
            try
            {
                List<string> columnsNames = new List<string>();
                foreach (DataColumn DataColumn in datatable.Columns)
                    columnsNames.Add(DataColumn.ColumnName);
                Temp = datatable.AsEnumerable().ToList().ConvertAll<T>(row => GetObject<T>(row, columnsNames));
                return Temp;
            }
            catch
            {
                return Temp;
            }

        }
        public static T TableToEntidad<T>(this DataTable datatable) where T : new()
        {
            T Temp = new T();
            try
            {
                List<string> columnsNames = new List<string>();
                foreach (DataColumn DataColumn in datatable.Columns)
                    columnsNames.Add(DataColumn.ColumnName);
                Temp = datatable.AsEnumerable().ToList().ConvertAll<T>(row => GetObject<T>(row, columnsNames))[0];
                return Temp;
            }
            catch
            {
                return Temp;
            }

        }
        public static T GetObject<T>(DataRow row, List<string> columnsName) where T : new()
        {
            T obj = new T();
            try
            {
                string columnname = "";
                string value = "";
                PropertyInfo[] Properties;
                Properties = typeof(T).GetProperties();
                foreach (PropertyInfo objProperty in Properties)
                {
                    columnname = columnsName.Find(name => name.ToLower() == objProperty.Name.ToLower());
                    if (!string.IsNullOrEmpty(columnname))
                    {
                        value = row[columnname].ToString();
                        if (!string.IsNullOrEmpty(value))
                        {
                            if (Nullable.GetUnderlyingType(objProperty.PropertyType) != null)
                            {
                                value = row[columnname].ToString().Replace("$", "").Replace(",", "");
                                objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(Nullable.GetUnderlyingType(objProperty.PropertyType).ToString())), null);
                            }
                            else
                            {
                                value = row[columnname].ToString().Replace("%", "");
                                objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(objProperty.PropertyType.ToString())), null);
                            }
                        }
                    }
                }
                return obj;
            }
            catch
            {
                return obj;
            }
        }

        public static DataTable ToDataTable<T>(this List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
        #endregion
    }
}
