using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Models.Enums;
using StudentManagementSystem.Models.ViewModels.Students;
using StudentManagementSystem.Services.Interface;

namespace StudentManagementSystem.Controllers;

public class StudentController : Controller
{
    private readonly IStudentService _studentService;
    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }
    public async Task<IActionResult> Index(string? searchTerm, StudentStatus? status)
    {
        var students = await _studentService
            .GetAllAsync(searchTerm, status);

        var viewModel = new StudentIndexViewModel
        {
            Students = students,
            SearchTerm = searchTerm,
            Status = status
        };

        return View(viewModel);
    }
    [HttpGet]
    public IActionResult Create() 
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateStudentViewModel viewModel) 
    {
        if (ModelState.IsValid) 
        {
            await _studentService.CreateAsync(viewModel);
            TempData["SuccessMessage"] = "Student was created successfully.";
            return RedirectToAction(nameof(Index));
        }
        return View(viewModel);
    }
    [HttpGet]
    public async Task<IActionResult> Details(int id) 
    {
        var student = await _studentService.GetByIdAsync(id);
        if (student == null) { return NotFound(); }
        return View(student);
    }
    [HttpGet]
    public async Task<IActionResult> Edit(int id) 
    {
        var student = await _studentService.GetForEditAsync(id);
        if (student == null) { return NotFound(); };
        return View(student);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(EditStudentViewModel viewModel) 
    {
        if (!ModelState.IsValid) return View(viewModel);
        var update = await _studentService.UpdateAsync(viewModel);
        if(!update) return NotFound();
        TempData["SuccessMessage"] = "Student was updated successfully.";
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Delete(int id) 
    {
        var student = await _studentService.GetForSoftDeleteAsync(id);
        if (student == null)  return NotFound();
        return View(student);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id) 
    {
        var deleted = await _studentService.SoftDeleteAsync(id);
        if (!deleted) return NotFound();
        TempData["SuccessMessage"] = "Student was deleted successfully.";
        return RedirectToAction(nameof(Index));
    }
}
