using Bulky.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Bulky.Controllers;

public class CategoryController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public IActionResult Index()
    {
        return View(_unitOfWork.CategoryRepository.GetAll());
    }

    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category category)
    {
        if (category.Name == category.DisplayOrder.ToString())
            ModelState.AddModelError("name", "Category & DisplayOrder Can't be the same");
        if (!ModelState.IsValid) return View();
        _unitOfWork.CategoryRepository.Add(category);
        _unitOfWork.Save();
        TempData["success"] = "Category Created Successfully";
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int? id)
    {
        var category = _unitOfWork.CategoryRepository.GetFirstOrDefault(u => u.Id == id);
        return View(category);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category category)
    {
        if (category.Name == category.DisplayOrder.ToString())
            ModelState.AddModelError("name", "Category & DisplayOrder Can't be the same");
        if (!ModelState.IsValid) return View();
        _unitOfWork.CategoryRepository.Update(category);
        _unitOfWork.Save();
        TempData["success"] = "Category Updated Successfully";
        return RedirectToAction("Index");
    }


    public IActionResult Delete(int? id)
    {
        var category = _unitOfWork.CategoryRepository.GetFirstOrDefault(u => u.Id == id);
        return View(category);
    }

    [HttpPost]
    public IActionResult Delete(Category category)
    {
        _unitOfWork.CategoryRepository.Remove(category);
        _unitOfWork.Save();
        TempData["success"] = "Category Deleted Successfully";
        return RedirectToAction("Index");
    }

}