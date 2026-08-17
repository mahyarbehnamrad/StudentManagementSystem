using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models.ViewModels.Courses;

public class EditCourseViewModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Filling Field {0} is Required")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "Filling Field {0} is Required")]
    [Range(1, 100)]
    public int MaxGrade { get; set; }
}
