namespace StudentManagementSystem.Models.ViewModels.Courses;

public class CourseIndexViewModel
{
    public string? SearchTerm { get; set; }
    public List<ListCourseViewModel> Courses { get; set; } = new();
}
