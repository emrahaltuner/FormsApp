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
            pruducts = pruducts.Where(p => p.Name!.ToLower().Contains(searchString)).ToList();
        }
        if (!string.IsNullOrEmpty(category) && category != "0")
        {
            ViewBag.category = category;
            pruducts = pruducts.Where(p => p.CategoryId.ToString() == category).ToList();
        }

        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name", category);
        return View(pruducts);
    }
    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product model, IFormFile imageFile)
    {
        var allowedExtensin = new[] { ".jpg", ".jpeg", ".png" };
        var ext = Path.GetExtension(imageFile.FileName);
        var randomFileName = string.Format($"{Guid.NewGuid()}{ext}");
        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);
        if (imageFile != null)
        {
            if (!allowedExtensin.Contains(ext))
            {
                ModelState.AddModelError("", "Geçerli bir resim seçin");
            }
        }
        if (ModelState.IsValid)
        {
            if (imageFile != null)
            {
                using (var strem = new FileStream(path, FileMode.Create))
                {
                    await imageFile.CopyToAsync(strem);
                }
                model.Image = randomFileName;
            }

            model.ProductId = Repository.Products.Count() + 1;

            Repository.CreateProduct(model);
            return RedirectToAction("Index");
        }
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        return View(model);
    }

    public IActionResult Edit(int? id)
    {
        var product = Repository.Products.FirstOrDefault(p => p.ProductId == id);
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");

        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Product model, IFormFile? imageFile)
    {

        if (id != model.ProductId)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {

            if (imageFile != null)
            {
                var ext = Path.GetExtension(imageFile.FileName);
                var randomFileName = string.Format($"{Guid.NewGuid()}{ext}");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);

                using (var strem = new FileStream(path, FileMode.Create))
                {
                    await imageFile.CopyToAsync(strem);
                }
                model.Image = randomFileName;
            }
            Repository.EditProduct(model);
            return RedirectToAction("Index");
        }
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        return RedirectToAction("model");
    }

}
