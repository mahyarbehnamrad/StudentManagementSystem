using StudentManagementSystem.Models.Enums;

namespace StudentManagementSystem.Models.ViewModels.Students;

public class DetailStudentViewModel
{
    public int Id { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public StudentStatus Status { get; set; }
}
