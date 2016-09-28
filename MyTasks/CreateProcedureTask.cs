using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace MyTasks
{
    public class CreateProcedureTask : Task
    {
        public string ConnectionString { get; set; }
        public ITaskItem CreateProcedureScript { get; set; }

        public override bool Execute()
        {
            string sql = SqlExecutor.ReadFile(CreateProcedureScript.ItemSpec);
            bool result = SqlExecutor.ExecuteSql(sql, ConnectionString);
            if (!(result || BuildEngine.ContinueOnError))
            {
                result = false;
            }
            return result;
        }
    }
}
