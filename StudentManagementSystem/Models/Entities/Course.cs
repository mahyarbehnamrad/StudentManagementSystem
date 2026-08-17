namespace StudentManagementSystem.Models.Entities;

public class Course:BaseEntity
{
    public string Name { get; set; }
    public int MaxGrade { get; set; }

    //Navigations
    public ICollection<StudentCourse> studentCourse { get; set; } = new List<StudentCourse>();
}
