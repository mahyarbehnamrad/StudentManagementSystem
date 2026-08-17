using StudentManagementSystem.Models.Enums;

namespace StudentManagementSystem.Models.ViewModels.Students;

public class ListStudentViewModel
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public StudentStatus Status { get; set; }
}
