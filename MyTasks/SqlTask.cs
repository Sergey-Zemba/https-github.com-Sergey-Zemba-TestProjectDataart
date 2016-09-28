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
        public ITaskItem PathToScript { get; set; }

        public override bool Execute()
        {
            bool result = ExecuteSql(ReadFile(PathToScript.ItemSpec));
            if (!(result || BuildEngine.ContinueOnError))
            {
                result = false;
            }
            return result;
        }

        private bool ExecuteSql(string sql)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(sql))
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    result = true;
                }
            }
            return result;
        }

        private string ReadFile(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
