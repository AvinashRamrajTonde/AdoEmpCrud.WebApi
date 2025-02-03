using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AdoEmpCrud.WebApi.Data.Core;
using AdoEmpCrud.WebApi.Helpers;
using AdoEmpCrud.WebApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.Sqlite;

namespace AdoEmpCrud.WebApi.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {

        public List<Employee> GetEmployees()
        {

            var employees = new List<Employee>();
            using (var connection = new SqliteConnection(DatabaseHelper.ConnectionString))
            {

                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = " SELECT * From Employees;";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employees.Add(new Employee
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Age = reader.GetInt16(2),
                            Role = reader.GetString(3)
                        });
                    }
                }
            }

            return employees;

        }

        public Employee GetEmpById(int Id)
        {
            var employee = new Employee { Name = "Default Name" };

            return employee;
        }

        public bool AddEmployee(Employee employee)
        {
            using var connection = new SqliteConnection(DatabaseHelper.ConnectionString);


            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @" INSERT INTO Employees (Name, Age, Role)
                VALUES (@Name, @Age, @Role);";

            command.Parameters.AddWithValue("@Name", employee.Name);
            command.Parameters.AddWithValue("@Age", employee.Age);
            command.Parameters.AddWithValue("@Role", employee.Role);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool UpdateEmployee(int Id, Employee employee)
        {
            if (employee == null || employee.Name == null)
            {
                return false;
            }
            using var connection = new SqliteConnection(DatabaseHelper.ConnectionString);


            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"UPDATE Employees SET 
                                        Name = @Name, 
                                        Age = @Age, 
                                        Role = @Role 
                                        WHERE Id = @Id;";

            command.Parameters.AddWithValue("@Name", employee.Name);
            command.Parameters.AddWithValue("@Age", employee.Age);
            command.Parameters.AddWithValue("@Role", employee.Role);
            command.Parameters.AddWithValue("@Id", Id);


            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool DeleteEmployee(int Id)
        {
            using var connection = new SqliteConnection(DatabaseHelper.ConnectionString);


            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"DELETE FROM Employees WHERE Id = @Id;";


            command.Parameters.AddWithValue("@Id", Id);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}