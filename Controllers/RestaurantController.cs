using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class RestaurantController : Controller
{
    private readonly RestaurantService _restaurantService;

    public RestaurantController(RestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }

    public async Task<IActionResult> Index()
    {
        var restaurants = await _restaurantService.GetRestaurantsAsync();
        return View(restaurants); // Returns view with list of restaurants
    }
}
