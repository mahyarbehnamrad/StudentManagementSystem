using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Models.ViewModels.Courses;
using StudentManagementSystem.Services.Interface;

namespace StudentManagementSystem.Controllers;

public class CourseController : Controller
{
    private readonly ICourseService _service;
    public CourseController(ICourseService service)
    {
        _service = service;
    }
    public async Task<IActionResult> Index() 
    {
        var courses = await _service.GetAllAsync();
        return View(courses);
    }
    [HttpGet]
    public async Task<IActionResult> Create() 
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateCourseViewModel viewModel) 
    {
        if(ModelState.IsValid) 
        {
            await _service.CreateAsync(viewModel);
            return RedirectToAction(nameof(Index));
        }
        return View(viewModel);
    }
    [HttpGet]
    public async Task<IActionResult> Details(int id) 
    {
        var course = await _service.GetByIdAsync(id);
        if (course == null) return NotFound();
        return View(course);
    }
    [HttpGet]
    public async Task<IActionResult> Delete(int id) 
    {
        var course = await _service.GetForDeleteAsync(id);
        if (course == null) return NotFound();
        return View(course);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id) 
    {
        var deleted = await _service.SoftDeleteAsync(id);
        if (!deleted) return NotFound();
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Edit(int id) 
    {
        var course = await _service.GetForEditAsync(id);
        if (course == null) return NotFound();
        return View(course);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(EditCourseViewModel viewModel) 
    {
        if (!ModelState.IsValid) return View(viewModel);
        var update = await _service.UpdateAsync(viewModel);
        if (update) return RedirectToAction(nameof(Index));
        return NotFound();
    }
}
