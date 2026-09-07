namespace StudentManagementSystem.Models.ViewModels.StudentCourses;

public class StudentCourseIndexViewModel
{
    public string? SearchTerm { get; set; }
    public List<ListStudentCourseViewModel> StudentCourses { get; set; } = new();
}
