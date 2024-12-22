using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormsApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FormsApp.Controllers;

public class HomeController : Controller
{



    public IActionResult Index(string searchString, string category)
    {

        var pruducts = Repository.Products;
        if (!string.IsNullOrEmpty(searchString))
        {
            ViewBag.searchString = searchString;
            pruducts = pruducts.Where(p => p.Name.ToLower().Contains(searchString)).ToList();
        }
        if (!string.IsNullOrEmpty(category) && category != "0")
        {
            ViewBag.category = category;
            pruducts = pruducts.Where(p => p.CategoryId.ToString() == category).ToList();
        }

        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name", category);
        return View(pruducts);
    }

    public IActionResult Privacy()
    {
        return View();
    }

}
