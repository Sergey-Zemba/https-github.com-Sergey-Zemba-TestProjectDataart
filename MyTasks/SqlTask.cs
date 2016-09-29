using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace MyTasks
{
    public class SqlTask : Task
    {
        public string ConnectionString { get; set; }
        public ITaskItem SqlScript { get; set; }

        public override bool Execute()
        {
            string sql = ReadFile(SqlScript.ItemSpec);
            return ExecuteSql(sql, ConnectionString);
        }

        private static bool ExecuteSql(string sql, string connectionString)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(sql))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    result = true;
                }
            }
            return result;
        }

        private static string ReadFile(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
