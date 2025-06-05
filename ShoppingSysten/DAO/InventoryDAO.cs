using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ShoppingSysten.Entity_class;

namespace ShoppingSysten.DAO
{
    public class InventoryDAO
    {
        private readonly string _connString;

        public InventoryDAO(string connectionString)
        {
            _connString = connectionString;
        }

        public async Task<bool> ExistsAsync(int productId)
        {
            const string sql = @"
                SELECT COUNT(1)
                  FROM Inventory
                 WHERE ProductId = @ProductId";

            using (SqlConnection conn = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = productId;
                    await conn.OpenAsync();
                    var cnt = (int)await cmd.ExecuteScalarAsync();
                    return cnt > 0;
                }
            }
        }

        public async Task<Inventory> GetByProductIdAsync(int productId)
        {
            const string sql = @"
                SELECT InventoryId, ProductId, Quantity, ReorderLevel, LastUpdate
                  FROM Inventory
                 WHERE ProductId = @ProductId";

            using (SqlConnection conn = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = productId;
                    await conn.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (!await reader.ReadAsync())
                            return null;

                        return new Inventory
                        {
                            inventoryId = reader.GetInt32(0),
                            productId = reader.GetInt32(1),
                            Quantity = reader.GetInt32(2),
                            ReorderLevel = reader.GetInt32(3),
                            lastUpdate = reader.GetDateTime(4)
                        };
                    }
                }
            }
        }

        public async Task<Inventory> GetByInventoryIdAsync(int invId)
        {
            const string sql = @"
                SELECT InventoryId, ProductId, Quantity, ReorderLevel, LastUpdate
                  FROM Inventory
                 WHERE InventoryId = @InvId";

            using (SqlConnection conn = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@InvId", SqlDbType.Int).Value = invId;
                    await conn.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (!await reader.ReadAsync())
                            return null;

                        return new Inventory
                        {
                            inventoryId = reader.GetInt32(0),
                            productId = reader.GetInt32(1),
                            Quantity = reader.GetInt32(2),
                            ReorderLevel = reader.GetInt32(3),
                            lastUpdate = reader.GetDateTime(4)
                        };
                    }
                }
            }
        }

        public async Task AddAsync(Inventory inventory)
        {
            const string sql = @"
                INSERT INTO Inventory (ProductId, Quantity, ReorderLevel, LastUpdate)
                VALUES (@ProductId, @Quantity, @ReorderLevel, @LastUpdate)";

            using (SqlConnection conn = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = inventory.productId;
                    cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = inventory.Quantity;
                    cmd.Parameters.Add("@ReorderLevel", SqlDbType.Int).Value = inventory.ReorderLevel;
                    cmd.Parameters.Add("@LastUpdate", SqlDbType.DateTime).Value = inventory.lastUpdate;

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Inventory inventory)
        {
            const string sql = @"
                UPDATE Inventory
                   SET Quantity     = @Quantity,
                       ReorderLevel = @ReorderLevel,
                       LastUpdate   = @LastUpdate
                 WHERE ProductId   = @ProductId";

            using (SqlConnection conn = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = inventory.Quantity;
                    cmd.Parameters.Add("@ReorderLevel", SqlDbType.Int).Value = inventory.ReorderLevel;
                    cmd.Parameters.Add("@LastUpdate", SqlDbType.DateTime).Value = inventory.lastUpdate;
                    cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = inventory.productId;

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<List<Inventory>> GetAllAsync()
        {
            const string sql = "SELECT * FROM Inventory";
            var list = new List<Inventory>();

            using (SqlConnection conn = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    await conn.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            list.Add(new Inventory
                            {
                                inventoryId = reader.GetInt32(0),
                                productId = reader.GetInt32(1),
                                Quantity = reader.GetInt32(2),
                                ReorderLevel = reader.GetInt32(3),
                                lastUpdate = reader.GetDateTime(4)
                            });
                        }
                    }
                }
            }

            return list;
        }
    }
}
