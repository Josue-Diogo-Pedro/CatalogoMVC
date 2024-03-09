using Microsoft.AspNetCore.Mvc;

namespace CatalogoMVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

}