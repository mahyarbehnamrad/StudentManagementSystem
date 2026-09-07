using Microsoft.AspNetCore.Mvc.Rendering;

namespace StudentManagementSystem.Models.ViewModels.Grades;

public class GradeIndexViewModel
{
    public string? SearchTerm { get; set; }
    public int? CourseId { get; set; }
    public List<SelectListItem> Courses { get; set; } = new();
    public List<ListGradeViewModel> Grades { get; set; } = new();
}
