using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_class;
using Interface;

namespace DAO
{
    class CustomerDAO : ICustomerDAO
    {
        private readonly string _connectionString;
        public CustomerDAO(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<int> InsertCustomer(Customer customer)
        {
            var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            var cmd = new SqlCommand("INSERT INTO Customer (CustomerId, name, gender, birth, address, phone, userName, password, score) OUTPUT INSERTED.ID VALUES (@CustomerId, @name, @gender, @birth, @address, @phone, @userName, @password, @score)", conn);
            cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
            cmd.Parameters.AddWithValue("@name", customer.name);
            cmd.Parameters.AddWithValue("@gender", customer.gender);
            cmd.Parameters.AddWithValue("@birth", customer.birth);
            cmd.Parameters.AddWithValue("@address", customer.address);
            cmd.Parameters.AddWithValue("@phone", customer.phone);
            cmd.Parameters.AddWithValue("@userName", customer.userName);
            cmd.Parameters.AddWithValue("@password", customer.password);
            cmd.Parameters.AddWithValue("@score", customer.score);
            return (int)await cmd.ExecuteScalarAsync();
        }

        public async Task<int> UpdateCustomer(Customer customer)
        {
            var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            var sql = @"
                 UPDATE Customer SET 
                    name = @name,
                    gender = @gender,
                    birth = @birth,
                    address = @address,
                    phone = @phone,
                    userName = @userName,
                    password = @password,
                    score = @score,
                WHERE Customer = @CustomerId";

            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
            cmd.Parameters.AddWithValue("@name", customer.name);
            cmd.Parameters.AddWithValue("@gender", customer.gender);
            cmd.Parameters.AddWithValue("@birth", customer.birth);
            cmd.Parameters.AddWithValue("@address", customer.address);
            cmd.Parameters.AddWithValue("@phone", customer.phone);
            cmd.Parameters.AddWithValue("@userName", customer.userName);
            cmd.Parameters.AddWithValue("@password", customer.password);
            cmd.Parameters.AddWithValue("@score", customer.score);
            return await cmd.ExecuteNonQueryAsync();
        }

        public async Task<int> DeleteCustomer(int customerId)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();

            var sql = "DELETE FROM Employee WHERE customerId = @CustomerId";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@EmployeeId", customerId);

            return await cmd.ExecuteNonQueryAsync();
        }

        public async Task<Customer> GetCustomerById(int customerId)
        {
            var customer = new Customer();

            var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();

            // Get Order
            var cmdCustomer = new SqlCommand("SELECT * FROM Orders WHERE customerId = @Id", conn);
            cmdCustomer.Parameters.AddWithValue("@ID", customerId);
            using var reader = await cmdCustomer.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                customer.CustomerId = reader.GetInt32(0);
                customer.name = reader.GetString(1);
                customer.birth = reader.GetDateTime(2);
                customer.phone = reader.GetString(3);
                customer.userName = reader.GetString(4);
                customer.password = reader.GetString(5);
                customer.gender = reader.GetString(6);
                customer.score = reader.GetInt32(7);
            }
            else return null;

            reader.Close();

            return customer;
        }
    }
}
