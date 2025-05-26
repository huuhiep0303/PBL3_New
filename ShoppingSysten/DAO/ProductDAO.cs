using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity_class;

namespace ShoppingSysten.DAO
{
    internal class ProductDAO
    {
        private readonly string _connectionString;
        public ProductDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<bool> AddAsync(product product)
        {
            const string sql = @"
                INSERT INTO Products
                   (ProductId, Name, Description, Price, CategoryId, Discount, IsAvailable)
                VALUES
                   (@Id, @Name, @Desc, @Price, @CatId, @Discount, @IsAvailable)";
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", product.id_product);
            cmd.Parameters.AddWithValue("@Name", product.name_product);
            cmd.Parameters.AddWithValue("@Desc", product.description_product);
            cmd.Parameters.AddWithValue("@Price", product.price);
            cmd.Parameters.AddWithValue("@CatId", product.CategoryId);
            cmd.Parameters.AddWithValue("@Discount", product.discount);
            cmd.Parameters.AddWithValue("@IsAvailable", product.isAvailable);

            await conn.OpenAsync();
            return await cmd.ExecuteNonQueryAsync() > 0;
        }

        public async Task<product> GetByIdAsync(int id)
        {
            const string sql = "SELECT * FROM Products WHERE ProductId = @Id";
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            if (!reader.Read()) return null;

            return new product
            {
                id_product = reader.GetInt32(reader.GetOrdinal("ProductId")),
                name_product = reader.GetString(reader.GetOrdinal("Name")),
                description_product = reader.GetString(reader.GetOrdinal("Description")),
                price = reader.GetDecimal(reader.GetOrdinal("Price")),
                CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                discount = reader.GetDecimal(reader.GetOrdinal("Discount")),
                isAvailable = reader.GetBoolean(reader.GetOrdinal("IsAvailable"))
            };
        }

        public async Task<List<product>> SearchAsync(string keyword)
        {
            const string sql = @"SELECT * FROM Products WHERE Name LIKE '%' + @kw + '%'";
            var list = new List<product>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@kw", keyword);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new product
                {
                    id_product = reader.GetInt32(reader.GetOrdinal("ProductId")),
                    name_product = reader.GetString(reader.GetOrdinal("Name")),
                    description_product = reader.GetString(reader.GetOrdinal("Description")),
                    price = reader.GetDecimal(reader.GetOrdinal("Price")),
                    CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                    discount = reader.GetDecimal(reader.GetOrdinal("Discount")),
                    isAvailable = reader.GetBoolean(reader.GetOrdinal("IsAvailable"))
                });
            }
            return list;
        }

        public async Task<bool> DeleteByNameAsync(string name)
        {
            const string sql = "DELETE FROM Products WHERE Name = @Name";
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Name", name);

            await conn.OpenAsync();
            return await cmd.ExecuteNonQueryAsync() > 0;
        }

        public async Task<bool> UpdateAsync(product product)
        {
            const string sql = @"
                UPDATE Products SET
                  Name = @Name,
                  Description = @Desc,
                  Price = @Price,
                  CategoryId = @CatId,
                  Discount = @Discount,
                  IsAvailable = @IsAvailable
                WHERE ProductId = @Id";
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", product.id_product);
            cmd.Parameters.AddWithValue("@Name", product.name_product);
            cmd.Parameters.AddWithValue("@Desc", product.description_product);
            cmd.Parameters.AddWithValue("@Price", product.price);
            cmd.Parameters.AddWithValue("@CatId", product.CategoryId);
            cmd.Parameters.AddWithValue("@Discount", product.discount);
            cmd.Parameters.AddWithValue("@IsAvailable", product.isAvailable);

            await conn.OpenAsync();
            return await cmd.ExecuteNonQueryAsync() > 0;
        }

        public async Task<List<product>> GetByCategoryIdAsync(int categoryId)
        {
            const string sql = "SELECT * FROM Products WHERE CategoryId = @CatId";
            var list = new List<product>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@CatId", categoryId);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new product
                {
                    id_product = reader.GetInt32(reader.GetOrdinal("ProductId")),
                    name_product = reader.GetString(reader.GetOrdinal("Name")),
                    description_product = reader.GetString(reader.GetOrdinal("Description")),
                    price = reader.GetDecimal(reader.GetOrdinal("Price")),
                    CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                    discount = reader.GetDecimal(reader.GetOrdinal("Discount")),
                    isAvailable = reader.GetBoolean(reader.GetOrdinal("IsAvailable"))
                });
            }
            return list;
        }
    }
}
