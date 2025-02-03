using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace AdoEmpCrud.WebApi.Helpers
{
    public class DatabaseHelper
    {
        private static string DbFileName = "EmployeeDb.db"; // Database Name
        public static string ConnectionString = $"Data Source={DbFileName};"; // Create Co

        public static void EnsureDatabase()
        {
            if (!File.Exists(DbFileName))
            {
                using (var connection = new SqliteConnection(ConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();

                    command.CommandText = @"
                                CREATE TABLE Employees(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Age INTEGER NOT NULL,
                    Role TEXT NOT NULL
                );
            ";
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}