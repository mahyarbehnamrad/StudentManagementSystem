using StudentManagementSystem.Models.Enums;

namespace StudentManagementSystem.Models.Entities;

public class Student:BaseEntity
{
    public  string Name { get; set; }
    public string Email { get; set; }
    public  string Family { get; set; }
    public string PhoneNumber { get; set; }

    //Enums
    public StudentStatus Status { get; set; }
    
    //Navigations
    public ICollection<StudentCourse> studentCourses { get; set; } = new List<StudentCourse>();

}
