using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models.ViewModels.Grades;

public class EditGradeViewModel
{
    public int Id { get; set; }
    public string StudentName { get; set; } = string.Empty;
    public string CourseName { get; set; } = string.Empty;
    public int MaxGrade { get; set; }
    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Grade cannot be negative.")]
    public decimal Score { get; set; }
}
