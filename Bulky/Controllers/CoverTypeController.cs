using Bulky.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Bulky.Controllers;
public class CoverTypeController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public CoverTypeController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public IActionResult Index() => View(_unitOfWork.CoverTypeRepository.GetAll());

    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CoverType coverType)
    {
        if (!ModelState.IsValid) return View();
        _unitOfWork.CoverTypeRepository.Add(coverType);
        _unitOfWork.Save();
        TempData["success"] = "Cover Type Create Successfully";
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int? id) => View(_unitOfWork.CoverTypeRepository.GetFirstOrDefault(coverType => coverType.Id == id));

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(CoverType coverType)
    {
        if (!ModelState.IsValid) return View();
        _unitOfWork.CoverTypeRepository.Update(coverType);
        _unitOfWork.Save();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int? id) => View(_unitOfWork.CoverTypeRepository.GetFirstOrDefault(coverType => coverType.Id == id));

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(CoverType coverType)
    {
        _unitOfWork.CoverTypeRepository.Remove(coverType);
        _unitOfWork.Save();
        return RedirectToAction("Index");
    }

}
