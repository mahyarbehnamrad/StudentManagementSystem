namespace StudentManagementSystem.Models.ViewModels.RecycleBin;

public class DeletedStudentViewModel
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public DateTime? DeletedAt { get; set; }
}
