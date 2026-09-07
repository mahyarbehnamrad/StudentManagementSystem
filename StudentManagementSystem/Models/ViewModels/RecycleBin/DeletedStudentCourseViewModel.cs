namespace StudentManagementSystem.Models.ViewModels.RecycleBin;

public class DeletedStudentCourseViewModel
{
    public int Id { get; set; }
    public string StudentName { get; set; } = string.Empty;
    public string CourseName { get; set; } = string.Empty;
    public DateTime? DeletedAt { get; set; }
}
