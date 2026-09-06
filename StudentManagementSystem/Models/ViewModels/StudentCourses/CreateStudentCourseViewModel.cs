using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models.ViewModels.StudentCourses;

public class CreateStudentCourseViewModel
{
    [Range(1, int.MaxValue, ErrorMessage = "Please select a student.")]
    public int StudentId { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Please select a course.")]
    public int CourseId { get; set; }

    public List<SelectListItem> Students { get; set; }
        = new List<SelectListItem>();
    public List<SelectListItem> Courses { get; set; }
        = new List<SelectListItem>();
}
