using Microsoft.AspNetCore.Mvc;

namespace Bulky.Controllers;

[Route("[controller]")]
public class CategoryController : Controller
{
    private readonly ILogger<CategoryController> _logger;

    public CategoryController(ILogger<CategoryController> logger) => _logger = logger;

    public IActionResult Index() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => View("Error!");
}