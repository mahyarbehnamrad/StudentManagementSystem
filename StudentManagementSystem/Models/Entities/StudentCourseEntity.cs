namespace StudentManagementSystem.Models.Entities;

public class StudentCourseEntity:BaseEntity
{
    public int StudentId { get; set; }
    public StudentEntity Student { get; set; } = null!;

    public int CourseId { get; set; }
    public CourseEntity Course { get; set; } = null!;

    public GradeEntity? Grade { get; set; }
}
