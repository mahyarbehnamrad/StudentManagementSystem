namespace StudentManagementSystem.Models.ViewModels.RecycleBin;

public class DeletedCourseViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime? DeletedAt { get; set; }
}
