using Repositories.IRepositories;
using Repositories.Items;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;

namespace Repositories.Repositories
{
    public class SQLToDoRepository : IToDoRepository
    {
        string connectionString;

        public SQLToDoRepository(string conn)
        {
            connectionString = conn;
        }

        public List<ToDo> GetList()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<ToDo>("SELECT * FROM Tasks").ToList();
            }
        }

        public ToDo Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<ToDo>("SELECT * FROM Tasks WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public void Create(ToDo category)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Tasks (Text, Description, Deadline, Complete, CategoryId) " +
                    "VALUES(@Text, @Description, @Deadline, @IsComplete, @CategoryId)";
                db.Execute(sqlQuery, category);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Tasks WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public void Update(ToDo toDo)
        {
            string isComplete = toDo.IsComplete ? "1" : "0";
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Tasks SET Text = @Text, Description = @Description, Deadline = @Deadline, Complete = @IsComplete, CategoryId = @CategoryId WHERE Id = @Id";
                db.Execute(sqlQuery, new {toDo.Id, toDo.Text, toDo.Description, toDo.Deadline, isComplete, toDo.CategoryId});
            }
        }

        public void UpdateState(ToDo toDo)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Tasks SET Complete = @IsComplete WHERE Id = @Id";
                db.Execute(sqlQuery, toDo);
            }
        }
    }
}
