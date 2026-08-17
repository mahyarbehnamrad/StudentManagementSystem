using StudentManagementSystem.Models.Enums;

namespace StudentManagementSystem.Models.Entities;

public class StudentEntity:BaseEntity
{
    public  string Name { get; set; }
    public string Email { get; set; }
    public  string Family { get; set; }
    public string PhoneNumber { get; set; }

    //Enums
    public StudentStatus Status { get; set; }
    
    //Navigations
    public ICollection<StudentCourseEntity> studentCourses { get; set; } = new List<StudentCourseEntity>();

}
