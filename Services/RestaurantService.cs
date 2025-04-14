using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

public class RestaurantService
{
    private readonly MySqlConnection _connection;

    public RestaurantService(MySqlConnection connection)
    {
        _connection = connection;
    }

    public async Task<List<Restaurant>> GetRestaurantsAsync()
    {
        await _connection.OpenAsync();
        var query = "SELECT * FROM Restaurant";
        var cmd = new MySqlCommand(query, _connection);

        var reader = await cmd.ExecuteReaderAsync();
        var restaurants = new List<Restaurant>();

        while (await reader.ReadAsync())
        {
            restaurants.Add(new Restaurant
            {
                Nom = reader["nom"].ToString(),
                Adresse = reader["adresse"].ToString(),
            });
        }

        await reader.CloseAsync();
        return restaurants;
    }
}

public class Restaurant
{
   public string Nom { get; set; } = string.Empty;
    public string Adresse { get; set; } = string.Empty;
}
