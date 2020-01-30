using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Configuration;
using react.net.Helpers;
using react.net.Models;

namespace react.net.Repositories.Task
{
    public class TaskRepository : RepositoryConnector, ITaskRepository
    {
        public TaskRepository(IConfiguration configuration) : base(configuration) { }

        public void Create(TaskModel obj)
        {
            string query = $@"INSERT INTO [dbo].[Task]
                            ([Name]
                            ,[Disabled])
                            VALUES
                            ('{obj.Name}'
                            ,'0')";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                con.Query(query);
            }
        }

        public IEnumerable<TaskModel> GetAll()
        {
            IEnumerable<TaskModel> result;
            string query = "SELECT * FROM Task";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                result = con.Query<TaskModel>(query);
            }

            return result;
        }

        public void Remove(int id)
        {
            string querySelect = $@"SELECT * FROM Task WHERE ID = {id}";
            string queryDisable = $@"UPDATE Task SET Disabled = 1 WHERE ID = {id}";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                var task = con.Query<TaskModel>(querySelect).FirstOrDefault();

                if (task == null)
                    throw new AppException("Task not found.");

                con.Execute(queryDisable);
            }
        }
    }
}