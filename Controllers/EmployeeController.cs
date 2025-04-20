using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_asp_net.Models;

namespace project_asp_net.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _context;

        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var employee = await _context.Employees.FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null) return NotFound();

            return View(employee);
        }

        // GET: Employee/Create
        public IActionResult Create()
{
    var employee = new Employee
    {
        Tables = new List<int>() // Ensure it's not null
    };
    return View(employee);
}

        // POST: Employee/Create
     [HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create(
    [Bind("Id,Nom,Prenom,Telephone,Role")] Employee employee,
    string tablesInput)
{
    if (!string.IsNullOrEmpty(tablesInput))
    {
        employee.Tables = tablesInput
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(t => int.TryParse(t.Trim(), out var num) ? num : (int?)null)
            .Where(t => t.HasValue)
            .Select(t => t.Value)
            .ToList();
    }
    else
    {
        employee.Tables = new List<int>();
    }

    if (ModelState.IsValid)
    {
        _context.Add(employee);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    return View(employee);
}



        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return NotFound();

            return View(employee);
        }

        // POST: Employee/Edit/5
     [HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Prenom,Telephone,Role,Tables")] Employee employee, string Tables)
{
    if (id != employee.Id) return NotFound();

    if (ModelState.IsValid)
    {
        if (!string.IsNullOrEmpty(Tables))
        {
            employee.Tables = Tables.Split(',')
                                     .Select(t => int.TryParse(t.Trim(), out int table) ? table : 0)
                                     .Where(t => t > 0)
                                     .ToList();
        }

        try
        {
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EmployeeExists(employee.Id)) return NotFound();
            else throw;
        }
        return RedirectToAction(nameof(Index));
    }
    return View(employee);
}


        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var employee = await _context.Employees.FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null) return NotFound();

            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null) _context.Employees.Remove(employee);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}