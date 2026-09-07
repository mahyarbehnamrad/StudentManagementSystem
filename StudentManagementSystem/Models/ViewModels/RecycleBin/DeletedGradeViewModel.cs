namespace StudentManagementSystem.Models.ViewModels.RecycleBin;

public class DeletedGradeViewModel
{
    public int Id { get; set; }
    public string StudentName { get; set; } = string.Empty;
    public string CourseName {  get; set; } = string.Empty;
    public decimal Score { get; set; }
    public DateTime? DeletedAt { get; set; }
}
