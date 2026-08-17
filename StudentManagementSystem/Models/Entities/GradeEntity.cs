namespace StudentManagementSystem.Models.Entities;

public class GradeEntity:BaseEntity
{
    public decimal Score { get; set; }
    public int StudentCourseId { get; set; }
    public StudentCourseEntity studentCourse { get; set; } = null!;
}
