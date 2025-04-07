using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace MvcMovie.Controllers
{
public class HelloWorldController : Controller
{
//
// GET: /HelloWorld/
public ActionResult Index()
{
 return View();
}
public ActionResult Privacy()
{
 return Privacy();
}

//
// GET: /HelloWorld/Welcome/
public ActionResult Welcome(string name, int level = 1) 
{ 
    ViewBag.Message = "Hello " + name; 
    ViewBag.Level = level; 
    return View(); 
} 
}
}