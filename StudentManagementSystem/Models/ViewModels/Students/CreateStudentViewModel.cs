using StudentManagementSystem.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models.ViewModels.Students;

public class CreateStudentViewModel
{
    [Required(ErrorMessage = "Filling Field {0} is Required")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "Filling Field {0} is Required")]
    [EmailAddress(ErrorMessage = "Template {0} is Wrong")]
    public string Email { get; set; } = string.Empty;
    [Required(ErrorMessage = "Filling Field {0} is Required")]
    public string Family { get; set; } = string.Empty;
    [Required(ErrorMessage = "Filling Field {0} is Required")]
    [Phone]
    public string PhoneNumber { get; set; } = string.Empty;

    //Enums
    public StudentStatus Status { get; set; }
}
