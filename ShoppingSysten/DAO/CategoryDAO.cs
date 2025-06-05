using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingSysten.Entity_class;
using Interface;


namespace ShoppingSysten.DAO
{
    public class CategoryDAO : ICategoryDAO
    {
        private readonly string _connectionString;
        public CategoryDAO (string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<bool> AddAsync(category cat)
        {
            const string sql = @"INSERT INTO Categories(CategoryName,CategoryDescription) VALUES(@Name,@Desc)";
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Name", cat.CategoryName);
            cmd.Parameters.AddWithValue("@Desc", cat.CategoryDescription);
            await conn.OpenAsync();
            return await cmd.ExecuteNonQueryAsync() > 0;
        }
        public async Task<category> GetByIdAsync(int id)
        {
            const string sql = "SELECT * FROM Categories WHERE CategoryId=@Id";
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            if (!reader.Read()) return null;
            return new category
            {
                CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                CategoryName = reader.GetString(reader.GetOrdinal("CategoryName")),
                CategoryDescription = reader.GetString(reader.GetOrdinal("CategoryDescription"))
            };
        }

        public async Task<List<category>> GetAllAsync()
        {
            const string sql = "SELECT * FROM Categories";
            var list = new List<category>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);
            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new category
                {
                    CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                    CategoryName = reader.GetString(reader.GetOrdinal("CategoryName")),
                    CategoryDescription = reader.GetString(reader.GetOrdinal("CategoryDescription"))
                });
            }
            return list;
        }
        public async Task<bool> UpdateAsync(category cat)
        {
            const string sql = @"UPDATE Categories SET CategoryName=@Name,CategoryDescription=@Desc WHERE CategoryId=@Id";
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", cat.CategoryId);
            cmd.Parameters.AddWithValue("@Name", cat.CategoryName);
            cmd.Parameters.AddWithValue("@Desc", cat.CategoryDescription);
            await conn.OpenAsync();
            return await cmd.ExecuteNonQueryAsync() > 0;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            const string sql = "DELETE FROM Categories WHERE CategoryId=@Id";
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            await conn.OpenAsync();
            return await cmd.ExecuteNonQueryAsync() > 0;
        }
        public async Task<bool> IsExistAsync(int id)
        {
            const string sql = "SELECT COUNT(1) FROM Categories WHERE CategoryId=@Id";
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            await conn.OpenAsync();
            return (int)await cmd.ExecuteScalarAsync() > 0;
        }
        public async Task<category> GetByNameAsync(string name)
        {
            const string sql = "SELECT * FROM Categories WHERE CategoryName=@Name";
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Name", name);
            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            if (!reader.Read()) return null;
            return new category
            {
                CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                CategoryName = reader.GetString(reader.GetOrdinal("CategoryName")),
                CategoryDescription = reader.GetString(reader.GetOrdinal("CategoryDescription"))
            };
        }
        public async Task<List<category>> SearchAsync(string keyword)
        {
            const string sql = @"SELECT * FROM Categories WHERE CategoryName LIKE '%' + @kw + '%'";
            var list = new List<category>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@kw", keyword);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new category
                {
                    CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                    CategoryName = reader.GetString(reader.GetOrdinal("CategoryName")),
                    CategoryDescription = reader.GetString(reader.GetOrdinal("CategoryDescription"))
                });
            }
            return list;

        }
    }
}
