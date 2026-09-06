using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Models.ViewModels.StudentCourses;
using StudentManagementSystem.Services.Interface;

namespace StudentManagementSystem.Controllers;

public class StudentCourseController : Controller
{
    private readonly IStudentCourseService _service;
    public StudentCourseController(IStudentCourseService courseService)
    {
        _service = courseService;
    }
    public async Task<IActionResult> Index() 
    {
        var studentcourses = await _service.GetAllAsync();
        return View(studentcourses);
    }
    [HttpGet]
    public async Task<IActionResult> Create() 
    {
        var viewModel = await _service.GetCreateModelAsync();
        return View(viewModel);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateStudentCourseViewModel viewModel) 
    {
        if (!ModelState.IsValid)
        {
            var model = await _service.GetCreateModelAsync();
            model.StudentId = viewModel.StudentId;
            model.CourseId = viewModel.CourseId;
            return View(model);
        }
        var created = await _service.CreateAsync(viewModel);
        if (!created) 
        {
            ModelState.AddModelError(string.Empty, "This student is already enrolled in this course.");

            var model = await _service.GetCreateModelAsync();
            model.StudentId = viewModel.StudentId;
            model.CourseId = viewModel.CourseId;
            return View(model);
        }
        TempData["SuccessMessage"] = "Student was enrolled successfully.";
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Delete(int id) 
    {
        var enrollment = await _service.GetForDeleteAsync(id);
        if (enrollment == null) return NotFound();
        return View(enrollment);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id) 
    {
        var enrollment = await _service.SoftDeleteAsync(id);
        if(!enrollment) return NotFound();
        TempData["SuccessMessage"] = "Enrollment  was removed successfully.";
        return RedirectToAction(nameof(Index));
    }
}
