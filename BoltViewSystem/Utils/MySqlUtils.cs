using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using MySql.Data.MySqlClient;

namespace BoltViewSystem.Utils
{
    public class MySqlUtils
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private static string connectionString = "server=localhost;database=123;user=root;password=123456;port=3306;";

        /// <summary>
        /// ExecuteNonQuery: 用于执行不返回数据集（如 INSERT、UPDATE 或 DELETE）的 SQL 命令。
        /// </summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="parameters">参数可选</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, params MySqlParameter[] parameters)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                using (var command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddRange(parameters);
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }



        public static List<T> ExecuteQueryToList<T>(string sql, params MySqlParameter[] parameters)
        {
            DataTable dt = ExecuteQuery(sql, parameters);
            return ConvertTo<T>(dt);
        }

        /// <summary>
        /// ExecuteQuery: 用于执行返回数据集的 SQL 查询，并将结果存储在 DataTable 中。
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataTable ExecuteQuery(string sql, params MySqlParameter[] parameters)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddRange(parameters);
                    //command.MysqlParameters.AddRange(parameters);
                    //command.Parameters.Add(parameters);

                    connection.Open();
                    var dataTable = new DataTable();
                    using (var reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                    return dataTable;
                }
            }
        }


        public static int ExecuteQueryCount(string sql, params MySqlParameter[] parameters)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddRange(parameters);

                    connection.Open();
                   var result = command.ExecuteScalar();
                    return Convert.ToInt32(result);
                }
            }
        }

        private static List<T> ConvertTo<T>(DataTable table)
        {
            if (table == null)
            {
                return null;
            }

            List<DataRow> rows = new List<DataRow>();

            foreach (DataRow row in table.Rows)
            {
                rows.Add(row);
            }

            return ConvertTo<T>(rows);
        }

        private static List<T> ConvertTo<T>(IList<DataRow> rows)
        {
            List<T> list = null;

            if (rows != null)
            {
                list = new List<T>();

                foreach (DataRow row in rows)
                {
                    T item = CreateItem<T>(row);
                    list.Add(item);
                }
            }

            return list;
        }

        private static T CreateItem<T>(DataRow row)
        {
            T obj = default(T);
            if (row != null)
            {
                obj = Activator.CreateInstance<T>();

                foreach (DataColumn column in row.Table.Columns)
                {
                    PropertyInfo prop = obj.GetType().GetProperty(column.ColumnName);
                    try
                    {
                        object value = row[column.ColumnName];
                        // 检查目标属性的类型是否与数据类型匹配，如果不匹配，则尝试进行类型转换
                        if (prop.PropertyType != value.GetType())
                        {
                            // 如果目标属性是Int32类型，但数据是Int64类型，则尝试将数据转换为Int32
                            if (prop.PropertyType == typeof(int) && value.GetType() == typeof(long))
                            {
                                value = Convert.ToInt32(value);
                            }
                            // 添加其他需要处理的类型转换逻辑...
                        }
                        prop.SetValue(obj, value, null);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }

            return obj;
        }
    }
}