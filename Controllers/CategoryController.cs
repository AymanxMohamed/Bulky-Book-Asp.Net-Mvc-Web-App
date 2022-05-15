using Microsoft.AspNetCore.Mvc;

namespace Bulky.Controllers;

public class CategoryController : Controller
{
  private readonly AppDbContext _db;

  public CategoryController(AppDbContext db) => _db = db;

  public IActionResult Index() => View(_db.Categories);

  public IActionResult Create() 
  { 
    return View();
  }
}