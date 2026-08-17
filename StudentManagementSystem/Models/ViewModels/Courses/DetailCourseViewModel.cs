using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models.ViewModels.Courses;

public class DetailCourseViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int MaxGrade { get; set; }
}
