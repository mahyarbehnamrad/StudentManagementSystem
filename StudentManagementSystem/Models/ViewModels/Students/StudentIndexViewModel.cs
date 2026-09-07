using StudentManagementSystem.Models.Enums;

namespace StudentManagementSystem.Models.ViewModels.Students;

public class StudentIndexViewModel
{
    public string? SearchTerm { get; set; }
    public StudentStatus? Status { get; set; }
    public List<ListStudentViewModel> Students { get; set; } = new();
}
