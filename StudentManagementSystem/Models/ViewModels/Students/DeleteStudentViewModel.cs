using StudentManagementSystem.Models.Enums;

namespace StudentManagementSystem.Models.ViewModels.Students;

public class DeleteStudentViewModel
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
}
