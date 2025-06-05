using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ShoppingSysten.Entity_class;
using BLL;
using Interface;

namespace ShoppingSysten.DAO
{
    public class ProductDAO : IProductDAO
    {
        private readonly string _connectionString;

        public ProductDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<bool> AddAsync(product product)
        {
            string sql = @"
                INSERT INTO Products
                   (ProductId, Name, Description, Price, CategoryId, Discount, IsAvailable)
                VALUES
                   (@Id, @Name, @Desc, @Price, @CatId, @Discount, @IsAvailable)";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
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
            }
        }

        public async Task<product> GetByIdAsync(int id)
        {
            string sql = "SELECT * FROM Products WHERE ProductId = @Id";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    await conn.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
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
                }
            }
        }

        public async Task<List<product>> SearchAsync(string keyword)
        {
            string sql = @"SELECT * FROM Products WHERE Name LIKE '%' + @kw + '%'";
            List<product> list = new List<product>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@kw", keyword);

                    await conn.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
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
                    }
                }
            }
            return list;
        }

        public async Task<bool> DeleteByNameAsync(string name)
        {
            string sql = "DELETE FROM Products WHERE Name = @Name";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);

                    await conn.OpenAsync();
                    return await cmd.ExecuteNonQueryAsync() > 0;
                }
            }
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            string sql = "DELETE FROM Products WHERE ProductId = @id";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    await conn.OpenAsync();
                    return await cmd.ExecuteNonQueryAsync() > 0;
                }
            }
        }

        public async Task<bool> UpdateAsync(product product)
        {
            string sql = @"
                UPDATE Products SET
                  Name = @Name,
                  Description = @Desc,
                  Price = @Price,
                  CategoryId = @CatId,
                  Discount = @Discount,
                  IsAvailable = @IsAvailable
                WHERE ProductId = @Id";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
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
            }
        }

        public async Task<List<product>> GetByCategoryIdAsync(int categoryId)
        {
            string sql = "SELECT * FROM Products WHERE CategoryId = @CatId";
            List<product> list = new List<product>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CatId", categoryId);

                    await conn.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
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
                    }
                }
            }
            return list;
        }

        public async Task<Dictionary<string, string>> GetAttributesAsync(int productId)
        {
            string sql = "SELECT AttrName, AttrValue FROM ProductAttributes WHERE ProductId = @Pid";
            Dictionary<string, string> attrs = new Dictionary<string, string>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Pid", productId);

                    await conn.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            string name = reader.GetString(0);
                            string value = reader.GetString(1);
                            attrs[name] = value;
                        }
                    }
                }
            }
            return attrs;
        }

        public async Task<bool> AddOrUpdateAttributeAsync(int productId, string attrName, string attrValue)
        {
            string updateSql = "UPDATE ProductAttributes SET AttrValue = @Value WHERE ProductId = @Pid AND AttrName = @Name";
            string insertSql = "INSERT INTO ProductAttributes(ProductId, AttrName, AttrValue) VALUES(@Pid, @Name, @Value)";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                using (SqlCommand upd = new SqlCommand(updateSql, conn))
                {
                    upd.Parameters.AddWithValue("@Pid", productId);
                    upd.Parameters.AddWithValue("@Name", attrName);
                    upd.Parameters.AddWithValue("@Value", attrValue);

                    int count = await upd.ExecuteNonQueryAsync();
                    if (count > 0) return true;
                }

                using (SqlCommand ins = new SqlCommand(insertSql, conn))
                {
                    ins.Parameters.AddWithValue("@Pid", productId);
                    ins.Parameters.AddWithValue("@Name", attrName);
                    ins.Parameters.AddWithValue("@Value", attrValue);

                    await ins.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> DeleteAttributeAsync(int productId, string attrName)
        {
            string sql = "DELETE FROM ProductAttributes WHERE ProductId = @Pid AND AttrName = @Name";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Pid", productId);
                    cmd.Parameters.AddWithValue("@Name", attrName);

                    await conn.OpenAsync();
                    return await cmd.ExecuteNonQueryAsync() > 0;
                }
            }
        }
    }
}
