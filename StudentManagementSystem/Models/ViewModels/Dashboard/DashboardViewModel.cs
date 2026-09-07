namespace StudentManagementSystem.Models.ViewModels.Dashboard;

public class DashboardViewModel
{
    public int StudentCount { get; set; }
    public int CourseCount { get; set; }
    public int EnrollmentCount { get; set; }
    public int GradeCount { get; set; }

    public int ActiveStudentCount { get; set; }
    public int InactiveStudentCount { get; set; }
    public int GraduatedStudentCount { get; set; }

    public int LowGradeCount { get; set; }
    public int MediumGradeCount { get; set; }
    public int HighGradeCount { get; set; }
}
