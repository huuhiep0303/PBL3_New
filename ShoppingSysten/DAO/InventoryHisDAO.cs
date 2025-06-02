using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity_class;
using Interface;

namespace DAO
{
    public class InventoryHisDAO : IHistoryDAO
    {
        private readonly string connectionString;

        public InventoryHisDAO(string connStr)
        {
            connectionString = connStr;
        }

        public async Task AddTransactionAsync(InventoryTransaction transaction)
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            string query = "INSERT INTO InventoryTransactions (ProductId, ActionType, QuantityChanged, ChangedTime, Note) VALUES (@ProductId, @ActionType, @QuantityChanged, @ChangedTime, @Note)";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ProductId", transaction.ProductId);
            cmd.Parameters.AddWithValue("@ActionType", transaction.ActionType);
            cmd.Parameters.AddWithValue("@QuantityChanged", transaction.QuantityChanged);
            cmd.Parameters.AddWithValue("@ChangedTime", transaction.ChangedTime);
            cmd.Parameters.AddWithValue("@Note", transaction.note);

            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task<List<InventoryTransaction>> GetHistoryByProductIdAsync(int productId)
        {
            List<InventoryTransaction> result = new();
            using SqlConnection conn = new SqlConnection(connectionString);
            string query = "SELECT * FROM InventoryTransactions WHERE ProductId = @ProductId";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ProductId", productId);

            await conn.OpenAsync();
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                result.Add(new InventoryTransaction
                {
                    TransactionId = reader.GetInt32(0),
                    ProductId = reader.GetInt32(1),
                    ActionType = reader.GetString(2),
                    QuantityChanged = reader.GetInt32(3),
                    ChangedTime = reader.GetDateTime(4),
                    note = reader.GetString(5)
                });
            }

            return result;
        }

        public async Task DeleteByTransactionIdAsync(int tranId)
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            string query = "DELETE FROM InventoryTransactions WHERE TransactionId = @TransactionId";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@TransactionId", tranId);

            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteByProductIdAsync(int productId)
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            string query = "DELETE FROM InventoryTransactions WHERE ProductId = @ProductId";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ProductId", productId);

            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }
    }
}
