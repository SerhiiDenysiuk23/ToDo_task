using Repositories.IRepositories;
using Repositories.Items;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;

namespace Repositories.Repositories
{
    public class SQLCategoryRepository : ICategoryRepository
    {
        string connectionString;
        public SQLCategoryRepository(string conn)
        {
            connectionString = conn;
        }
        public List<Category> GetList()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Category>("SELECT * FROM Category").ToList();
            }
        }

        public Category Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Category>("SELECT * FROM Category WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public void Create(Category category)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Category (Name) VALUES(@Name)";
                db.Execute(sqlQuery, category);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Category WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}
