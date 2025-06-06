using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_class;

namespace ShoppingSysten.DAO
{
    class EmployeeDAO
    {
        private readonly string _connectionString;
        public EmployeeDAO(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<int> InsertEmployee(Employee employee)
        {
            var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = new SqlCommand("INSERT INTO Employee (EmployeeId, name, gender, birth, address, phone, userName, password, Role, WorkPlace, Shift, Salary) OUTPUT INSERTED.ID VALUES (@EmployeeId, @name, @gender, @birth, @address, @phone, @userName, @password, @Role, @WorkPlace, @Shift, @Salary)", conn);
            cmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
            cmd.Parameters.AddWithValue("@name", employee.name);
            cmd.Parameters.AddWithValue("@gender", employee.gender);
            cmd.Parameters.AddWithValue("@birth", employee.birth);
            cmd.Parameters.AddWithValue("@address", employee.address);
            cmd.Parameters.AddWithValue("@phone", employee.phone);
            cmd.Parameters.AddWithValue("@userName", employee.userName);
            cmd.Parameters.AddWithValue("@password", employee.password);
            cmd.Parameters.AddWithValue("@Role", employee.Role);
            cmd.Parameters.AddWithValue("@WorkPlace", employee.WorkPlace);
            cmd.Parameters.AddWithValue("@Shift", employee.Shift);
            cmd.Parameters.AddWithValue("@Salary", employee.Salary);
            return (int)await cmd.ExecuteScalarAsync();
        }

        public async Task<int> UpdateEmployee(Employee employee)
        {
            var conn = new SqlConnection (_connectionString);
            await conn.OpenAsync();
            var sql = @"
                 UPDATE Employee SET 
                    name = @name,
                    gender = @gender,
                    birth = @birth,
                    address = @address,
                    phone = @phone,
                    userName = @userName,
                    password = @password,
                    Role = @Role,
                    WorkPlace = @WorkPlace,
                    Shift = @Shift,
                    Salary = @Salary
                WHERE EmployeeId = @EmployeeId";

            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
            cmd.Parameters.AddWithValue("@name", employee.name);
            cmd.Parameters.AddWithValue("@gender", employee.gender);
            cmd.Parameters.AddWithValue("@birth", employee.birth);
            cmd.Parameters.AddWithValue("@address", employee.address);
            cmd.Parameters.AddWithValue("@phone", employee.phone);
            cmd.Parameters.AddWithValue("@userName", employee.userName);
            cmd.Parameters.AddWithValue("@password", employee.password);
            cmd.Parameters.AddWithValue("@Role", employee.Role);
            cmd.Parameters.AddWithValue("@WorkPlace", employee.WorkPlace);
            cmd.Parameters.AddWithValue("@Shift", employee.Shift);
            cmd.Parameters.AddWithValue("@Salary", employee.Salary);
            return await cmd.ExecuteNonQueryAsync();
        }

        public async Task<int> DeleteCustomer(int employeeId)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();

            var sql = "DELETE FROM Employee WHERE EmployeeId = @EmployeeId";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@EmployeeId", employeeId);

            return await cmd.ExecuteNonQueryAsync();
        }

        public async Task<Employee> GetCustomerById(int employeeId)
        {
            var employee = new Employee();

            var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();

            // Get Order
            var cmdEmployee = new SqlCommand("SELECT * FROM Orders WHERE customerId = @Id", conn);
            cmdEmployee.Parameters.AddWithValue("@ID", employeeId);
            using var reader = await cmdEmployee.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                employee.EmployeeId = reader.GetInt32(0);
                employee.name = reader.GetString(1);
                employee.gender = reader.GetString(2);
                employee.birth = reader.GetDateTime(3);
                employee.phone = reader.GetString(4);
                employee.userName = reader.GetString(5);
                employee.password = reader.GetString(6);
                employee.Role = reader.GetString(7);
                employee.WorkPlace = reader.GetString(8);
                employee.Shift = reader.GetInt32(9);
                employee.Salary = reader.GetDouble(10);
                
                
            }
            else return null;

            reader.Close();

            return employee;
        }
    }
}
