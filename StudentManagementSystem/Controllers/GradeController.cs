using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Models.ViewModels.Grades;
using StudentManagementSystem.Services.Interface;

namespace StudentManagementSystem.Controllers;

public class GradeController : Controller
{
    private readonly IGradeService _service;
    public GradeController(IGradeService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index(string? searchTerm, int? courseId)
    {
        var grades = await _service.GetAllAsync(searchTerm, courseId);

        var courses = await _service.GetCourseOptionsAsync();

        var viewModel = new GradeIndexViewModel
        {
            Grades = grades,
            Courses = courses,
            SearchTerm = searchTerm,
            CourseId = courseId
        };

        return View(viewModel);
    }
    [HttpGet]
    public async Task<IActionResult> Create() 
    {
        var grade = await _service.GetForCreateModelAsync();
        return View(grade);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateGradeViewModel viewModel) 
    {
        if (!ModelState.IsValid) 
        {
            var model = await _service.GetForCreateModelAsync();
            model.StudentCourseId = viewModel.StudentCourseId;
            model.Score = viewModel.Score;
            return View(model);
        }
        var created = await _service.CreateAsync(viewModel);
        if (!created) 
        {
            ModelState.AddModelError(string.Empty, "The grade is invalid or a grade already exists for this enrollment.");
            var model = await _service.GetForCreateModelAsync();
            model.StudentCourseId = viewModel.StudentCourseId;
            model.Score = viewModel.Score;
            return View(model);
        }
        TempData["SuccessMessage"] = "Grade was added successfully.";
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Edit(int id) 
    {
        var grade = await _service.GetForEditModelAsync(id);
        if (grade == null) return NotFound();
        return View(grade); 
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(EditGradeViewModel viewModel) 
    {
        if (!ModelState.IsValid) 
        {
            return View(viewModel);
        }
        var updated = await _service.UpdateAsync(viewModel);
        if (!updated) 
        {
            ModelState.AddModelError(string.Empty, "The grade is invalid.");
            return View(viewModel);
        }
        TempData["SuccessMessage"] = "Grade was updated successfully.";
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Delete(int id) 
    {
        var grade = await _service.GetForSoftDeleteAsync(id);
        if (grade == null) return NotFound();
        return View(grade);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id) 
    {
        var deleted = await _service.SoftDeleteAsync(id);
        if (!deleted) return NotFound();
        TempData["SuccessMessage"] = "Grade was deleted successfully.";
        return RedirectToAction(nameof(Index));
    }
}
