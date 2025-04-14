using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using projet.net.Models;
namespace projet.net.Services
{public class EmployeeService
{
    private readonly MySqlConnection _connection;

    public EmployeeService(MySqlConnection connection)
    {
        _connection = connection;
    }

    public async Task<List<Employee>> GetEmployeesAsync()
    {
        var employees = new List<Employee>();

        if (_connection.State != System.Data.ConnectionState.Open)
            await _connection.OpenAsync();

        var query = "SELECT * FROM Employe";
        using var cmd = new MySqlCommand(query, _connection);
        using var reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            employees.Add(new Employee
            {
                Id = Convert.ToInt32(reader["id_employe"]),
                Nom = reader["nom"].ToString() ?? string.Empty,
                Prenom = reader["prenom"].ToString() ?? string.Empty,
                Poste = reader["role"].ToString() ?? string.Empty,
                IdRestaurant = Convert.ToInt32(reader["id_restaurant"])
            });
        }

        return employees;
    }

    // This method updates the role of an employee
    public async Task<bool> UpdateEmployeeRoleAsync(int id, string newRole)
    {
        if (_connection.State != System.Data.ConnectionState.Open)
            await _connection.OpenAsync();

        // Define the query to update the employee's role
        var query = @"UPDATE Employe SET role = @newRole WHERE id_employe = @id";

        using var cmd = new MySqlCommand(query, _connection);
        cmd.Parameters.AddWithValue("@newRole", newRole);  // Set the new role
        cmd.Parameters.AddWithValue("@id", id);  // Set the employee ID

        // Execute the update query and check if any rows were affected
        var rowsAffected = await cmd.ExecuteNonQueryAsync();

        // Return true if the update was successful (i.e., at least one row was updated)
        return rowsAffected > 0;
    }
}
}