namespace StudentManagementSystem.Models.ViewModels.Grades;

public class ListGradeViewModel
{
    public int Id { get; set; }
    public string StudentName { get; set; } = string.Empty;
    public string CourseName { get; set; } = string.Empty;
    public decimal Score { get; set; }
    public int MaxGrade { get; set; }
    public decimal Percentage { get; set; }
}
