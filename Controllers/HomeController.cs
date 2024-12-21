using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormsApp.Models;

namespace FormsApp.Controllers;

public class HomeController : Controller
{



    public IActionResult Index(string searchString)
    {
        var pruducts = Repository.Products;
        if (!string.IsNullOrEmpty(searchString))
        {
            pruducts = pruducts.Where(p => p.Name.ToLower().Contains(searchString)).ToList();
        }
        return View(pruducts);
    }

    public IActionResult Privacy()
    {
        return View();
    }

}
