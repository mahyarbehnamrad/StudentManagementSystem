using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Models.Data;
using StudentManagementSystem.Services.Interface;

namespace StudentManagementSystem.Controllers;

public class RecycleBinController : Controller
{
    private readonly IRecycleBinRestoreService _restoreService;
    public RecycleBinController(IRecycleBinRestoreService restoreService)
    {
        _restoreService = restoreService;
    }
    public async Task<IActionResult> Index() 
    {
        var viewmodel = await _restoreService.GetAllAsync();
        return View(viewmodel);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RestoreStudent(int Id) 
    {
        var restore = await _restoreService.RestoreStudentViewModelAsync(Id);
        if (!restore) return NotFound();

        TempData["SuccessMessage"] = "Student was restored successfully.";

        return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RestoreCourse(int Id)
    {
        var restore = await _restoreService.RestoreCourseViewModelAsync(Id);

        if (!restore) return NotFound();

        TempData["SuccessMessage"] = "course was restored successfully.";

        return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RestoreStudentCourse(int Id) 
    {
        var restore = await _restoreService.RestoreStudentCourseViewModelAsync(Id);

        if (!restore) return BadRequest();

        TempData["SuccessMessage"] = "Enrollment was restored successfully.";

        return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RestoreGrade(int Id)
    {
        var restore = await _restoreService.RestoreGradeViewModelAsync(Id);

        if (!restore) return BadRequest();

        TempData["SuccessMessage"] = "Grade was restored successfully.";

        return RedirectToAction(nameof(Index));
    }
}
