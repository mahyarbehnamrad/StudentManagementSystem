namespace StudentManagementSystem.Models.Entities;

public class CourseEntity:BaseEntity
{
    public string Name { get; set; }
    public int MaxGrade { get; set; }

    //Navigations
    public ICollection<StudentCourseEntity> studentCourse { get; set; } = new List<StudentCourseEntity>();
}
