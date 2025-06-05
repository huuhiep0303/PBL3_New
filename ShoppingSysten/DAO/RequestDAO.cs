using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSysten.DAO
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using ShoppingSysten.Entity_class;

    namespace DAL
    {
        public class RequestDAO
        {
            private readonly string connectionString;

            public RequestDAO(string connectionString)
            {
                this.connectionString = connectionString;
            }

            public async Task<int> InsertAsync(ReturnRequest request)
            {
                var imagesConcatenated = string.Join(";", request.ImagePaths);
                using (var conn = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO ReturnRequests (OrderId, ProductId, Quantity, Reason, RequestAt, ImagePaths, Status)
                                 OUTPUT INSERTED.ReturnId
                                 VALUES (@OrderId, @ProductId, @Quantity, @Reason,@RequestAt, @ImagePaths, @Status)";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@OrderId", request.OrderId);
                        cmd.Parameters.AddWithValue("@ProductId", request.ProductId);
                        cmd.Parameters.AddWithValue("@Quantity", request.Quantity);
                        cmd.Parameters.AddWithValue("@Reason", request.Reason);
                        cmd.Parameters.AddWithValue("@RequestAt", DateTime.Now);
                        cmd.Parameters.AddWithValue("@ImagePaths", imagesConcatenated);
                        cmd.Parameters.AddWithValue("@Status", (int)request.Status);

                        await conn.OpenAsync();
                        return (int)await cmd.ExecuteScalarAsync();
                    }
                }
            }

            public async Task<List<ReturnRequest>> GetByStatusAsync(RequestStatus status)
            {
                var list = new List<ReturnRequest>();
                using (var conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM ReturnRequests WHERE Status = @Status";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Status", (int)status);
                        await conn.OpenAsync();
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var images = reader["ImagePaths"].ToString().Split(';');
                                var req = new ReturnRequest(
                                    Convert.ToInt32(reader["OrderId"]),
                                    Convert.ToInt32(reader["ProductId"]),
                                    
                                    Convert.ToInt32(reader["Quantity"]),
                                    reader["Reason"].ToString(),
                                    images)
                                {
                                    RequestAt = Convert.ToDateTime(reader["RequestAt"]),
                                    ProcessAt = reader["ProcessAt"] == DBNull.Value ? null : (DateTime?)reader["ProcessAt"],
                                    ReturnId = Convert.ToInt32(reader["ReturnId"]),
                                    Status = (RequestStatus)Convert.ToInt32(reader["Status"])
                                };
                                list.Add(req);
                            }
                        }
                    }
                }
                return list;
            }

            public async Task<ReturnRequest> GetByIdAsync(int returnId)
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM ReturnRequests WHERE ReturnId = @ReturnId";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ReturnId", returnId);
                        await conn.OpenAsync();
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                var images = reader["ImagePaths"].ToString().Split(';');
                                var req = new ReturnRequest(
                                    Convert.ToInt32(reader["OrderId"]),
                                    Convert.ToInt32(reader["ProductId"]),
                                    Convert.ToInt32(reader["Quantity"]),
                                    reader["Reason"].ToString(),
                                    images)
                                {
                                    RequestAt = Convert.ToDateTime(reader["RequestAt"]),
                                    ProcessAt = reader["ProcessAt"] == DBNull.Value ? null : (DateTime?)reader["ProcessAt"],
                                    ReturnId = Convert.ToInt32(reader["ReturnId"]),
                                    Status = (RequestStatus)Convert.ToInt32(reader["Status"])
                                };
                                return req;
                            }
                            return null;
                        }
                    }
                }
            }

            public async Task<bool> UpdateStatusAsync(int returnId, RequestStatus newStatus)
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE ReturnRequests SET Status = @Status, ProcessAt = @ProcessAt WHERE ReturnId = @ReturnId";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Status", (int)newStatus);
                        cmd.Parameters.AddWithValue("@ProcessAt", DateTime.Now);
                        cmd.Parameters.AddWithValue("@ReturnId", returnId);
                        await conn.OpenAsync();
                        int affectedRows = await cmd.ExecuteNonQueryAsync();
                        return affectedRows > 0;
                    }
                }
            }

            public async Task<List<ReturnRequest>> GetAllAsync()
            {
                var list = new List<ReturnRequest>();
                using (var conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM ReturnRequests";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        await conn.OpenAsync();
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var images = reader["ImagePaths"].ToString().Split(';');
                                var req = new ReturnRequest(
                                    Convert.ToInt32(reader["OrderId"]),
                                    Convert.ToInt32(reader["ProductId"]),
                                    Convert.ToInt32(reader["Quantity"]),
                                    reader["Reason"].ToString(),
                                    images)
                                {
                                    RequestAt = Convert.ToDateTime(reader["RequestAt"]),
                                    ProcessAt = reader["ProcessAt"] == DBNull.Value ? null : (DateTime?)reader["ProcessAt"],
                                    ReturnId = Convert.ToInt32(reader["ReturnId"]),
                                    Status = (RequestStatus)Convert.ToInt32(reader["Status"])
                                };
                                list.Add(req);
                            }
                        }
                    }
                }
                return list;
            }
        }
    }

}
