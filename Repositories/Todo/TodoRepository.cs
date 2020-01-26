using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Configuration;
using react.net.Helpers;
using react.net.Models;

namespace react.net.Repositories.Todo
{
    public class TodoRepository : RepositoryConnector, ITodoRepository
    {
        public TodoRepository(IConfiguration configuration) : base(configuration) { }

        public void Create(TodoModel obj)
        {
            string query = $@"INSERT INTO [dbo].[Todo]
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

        public IEnumerable<TodoModel> GetAll()
        {
            IEnumerable<TodoModel> result;
            string query = "SELECT * FROM Todo";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                result = con.Query<TodoModel>(query);
            }

            return result;
        }

        public void Remove(int id)
        {
            string querySelect = $@"SELECT * FROM Todo WHERE ID = {id}";
            string queryDisable = $@"UPDATE Todo SET Disabled = 1 WHERE ID = {id}";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                var user = con.Query<TodoModel>(querySelect).FirstOrDefault();

                if (user == null)
                    throw new AppException("User not found.");

                con.Execute(queryDisable);
            }
        }
    }
}