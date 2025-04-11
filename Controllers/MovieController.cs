using Microsoft.AspNetCore.Mvc;
using project_asp_net.Models;

public class MoviesController : Controller
{
    private readonly MovieContext _context;

    public MoviesController(MovieContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var movies = _context.Movies.ToList();
        return View(movies);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

// Traite l'envoi du formulaire
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(movie);
        
    }
}
