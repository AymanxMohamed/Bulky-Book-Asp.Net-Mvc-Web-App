using Microsoft.AspNetCore.Mvc;

namespace Bulky.Controllers;

public class CategoryController : Controller
{
    private readonly AppDbContext _db;

    public CategoryController(AppDbContext db) => _db = db;

    public IActionResult Index()
    {
        return View(_db.Categories);
    }

    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category category)
    {
        if (category.Name == category.DisplayOrder.ToString())
            ModelState.AddModelError("name", "Category & DisplayOrder Can't be the same");
        if (!ModelState.IsValid) return View();

        _db.Categories?.Add(category);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int? id)
    {
        var category = _db.Categories?.Find(id);
        if (category == null) return NotFound();
        return View(category);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category category)
    {
        if (category.Name == category.DisplayOrder.ToString())
            ModelState.AddModelError("name", "Category & DisplayOrder Can't be the same");
        if (!ModelState.IsValid) return View();
        _db.Categories?.Update(category);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }


    public IActionResult Delete(int? id)
    {
        var category = _db.Categories?.Find(id);
        if (category == null) return NotFound();
        _db.Categories?.Remove(category);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

}