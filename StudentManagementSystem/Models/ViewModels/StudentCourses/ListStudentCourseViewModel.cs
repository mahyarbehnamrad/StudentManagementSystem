namespace StudentManagementSystem.Models.ViewModels.StudentCourses;

public class ListStudentCourseViewModel
{
    public int Id { get; set; }
    public string StudentName { get; set; } = string.Empty;
    public string CourseName { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public int MaxGrade { get; set; }
}
