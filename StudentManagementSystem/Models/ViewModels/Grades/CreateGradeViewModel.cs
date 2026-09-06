using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models.ViewModels.Grades;

public class CreateGradeViewModel
{

    [Range(1, int.MaxValue, ErrorMessage = "Please select an enrollment.")]
    public int StudentCourseId { get; set; }
    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Grade cannot be negative.")]
    public decimal Score { get; set; }
    public List<SelectListItem> Enrollments { get; set; }
        = new List<SelectListItem>();
}
