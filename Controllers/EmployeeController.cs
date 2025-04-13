using Microsoft.AspNetCore.Mvc;
using projet.net.Models;    // Make sure the model is imported
using projet.net.Services;  // Make sure the service is imported
using System.Threading.Tasks;
 
 
public class EmployeeController : Controller
{
    private readonly EmployeeService _employeeService;

    public EmployeeController(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    // This action displays the list of employees
    public async Task<IActionResult> Index()
    {
        var employees = await _employeeService.GetEmployeesAsync();
        return View(employees);  // Pass the list of employees to the view
    }

    // This action handles the role change
    [HttpPost]
    public async Task<IActionResult> ChangeRole(int id, string newRole)
    {
        // Ensure the newRole is valid before proceeding
        if (string.IsNullOrEmpty(newRole) || (newRole != "hotesse" && newRole != "serveur" && newRole != "admin"))
        {
            return BadRequest("Invalid role");
        }

        // Call the service to update the role in the database
        var success = await _employeeService.UpdateEmployeeRoleAsync(id, newRole);

        if (success)
        {
            // Redirect to the list of employees after updating the role
            return RedirectToAction("Index");
        }

        return BadRequest("Error updating role");
    }
}
