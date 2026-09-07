using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models.Data;
using StudentManagementSystem.Models.Enums;
using StudentManagementSystem.Models.ViewModels.Dashboard;
using StudentManagementSystem.Services.Interface;

namespace StudentManagementSystem.Services.Service;

public class DashboardService : IDashboardService
{
    private readonly ApplicationDbContext _dbContext;
    public DashboardService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<DashboardViewModel> GetStatisticsAsync()
    {
        return new DashboardViewModel
        {
            StudentCount = await _dbContext.Students.CountAsync(),

            CourseCount = await _dbContext.Courses.CountAsync(),

            EnrollmentCount = await _dbContext.studentCourses.CountAsync(),

            GradeCount = await _dbContext.grades.CountAsync(),

            ActiveStudentCount = await _dbContext.Students
            .CountAsync(s => s.Status == StudentStatus.Active),

            InactiveStudentCount = await _dbContext.Students
            .CountAsync(s => s.Status == StudentStatus.Inactive),

            GraduatedStudentCount = await _dbContext.Students
            .CountAsync(s => s.Status == StudentStatus.Graduated),

            LowGradeCount = await _dbContext.grades
                .CountAsync(g =>
                g.studentCourse.Course.MaxGrade > 0 &&
                (g.Score / g.studentCourse.Course.MaxGrade) * 100 < 50),

            MediumGradeCount = await _dbContext.grades
                .CountAsync(g =>
                g.studentCourse.Course.MaxGrade > 0 &&
                (g.Score / g.studentCourse.Course.MaxGrade) * 100 >= 50 &&
                (g.Score / g.studentCourse.Course.MaxGrade) * 100 < 80),

            HighGradeCount = await _dbContext.grades
                .CountAsync(g =>
                g.studentCourse.Course.MaxGrade > 0 &&
                (g.Score / g.studentCourse.Course.MaxGrade) * 100 >= 80)
        };
    }
}
