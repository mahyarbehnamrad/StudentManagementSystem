namespace StudentManagementSystem.Models.ViewModels.Grades;

public class DeleteGradeViewModel
{
    public int Id { get; set; }
    public string StudentName { get; set; } = string.Empty;
    public string CourseName { get; set; } = string.Empty;
    public decimal Score { get; set; }
}
