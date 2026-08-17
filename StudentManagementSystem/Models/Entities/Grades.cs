namespace StudentManagementSystem.Models.Entities;

public class Grades:BaseEntity
{
    public decimal Score { get; set; }
    public int StudentCourseId { get; set; }
    public StudentCourse studentCourse { get; set; } = null!;
}
