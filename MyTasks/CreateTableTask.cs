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
    public class CreateTableTask : Task
    {
        public string ConnectionString { get; set; }
        public ITaskItem CreateScript { get; set; }

        public override bool Execute()
        {
            string sql = SqlExecutor.ReadFile(CreateScript.ItemSpec);
            bool result = SqlExecutor.ExecuteSql(sql, ConnectionString);
            if (!(result || BuildEngine.ContinueOnError))
            {
                result = false;
            }
            return result;
        }
    }
}
