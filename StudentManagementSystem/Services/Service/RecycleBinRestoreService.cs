using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models.Data;
using StudentManagementSystem.Models.ViewModels.RecycleBin;
using StudentManagementSystem.Services.Interface;

namespace StudentManagementSystem.Services.Service;

public class RecycleBinRestoreService : IRecycleBinRestoreService
{
    private readonly ApplicationDbContext _dbContext;
    public RecycleBinRestoreService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<RecycleBinViewModel> GetAllAsync()
    {
        var viewmodel = new RecycleBinViewModel
        {
            Students = await _dbContext.Students
                .AsNoTracking()
                .IgnoreQueryFilters()
                .Where(s => s.IsDeleted)
                .Select(s => new DeletedStudentViewModel
                {
                    Id = s.Id,
                    FullName = s.Name + " " + s.Family,
                    DeletedAt = s.DeletedAt
                })
                .ToListAsync(),
            Courses = await _dbContext.Courses
                .AsNoTracking()
                .IgnoreQueryFilters()
                .Where(c => c.IsDeleted)
                .Select(c=> new DeletedCourseViewModel 
                {
                    Id=c.Id,
                    Name = c.Name,
                    DeletedAt = c.DeletedAt
                })
                .ToListAsync(),
            StudentCourses = await _dbContext.studentCourses
                .AsNoTracking()
                .IgnoreQueryFilters()
                .Where(sc => sc.IsDeleted)
                .Select(sc => new DeletedStudentCourseViewModel
                {
                    Id = sc.Id,
                    CourseName = sc.Course.Name,
                    StudentName = sc.Student.Name + " " + sc.Student.Family,
                    DeletedAt = sc.DeletedAt
                })
                .ToListAsync(),
            Grades = await _dbContext.grades
                .AsNoTracking()
                .IgnoreQueryFilters()
                .Where(g => g.IsDeleted)
                .Select(g => new DeletedGradeViewModel
                {
                    Id = g.Id,
                    CourseName = g.studentCourse.Course.Name,
                    StudentName = g.studentCourse.Student.Name + " " + g.studentCourse.Student.Family,
                    Score = g.Score,
                    DeletedAt = g.DeletedAt
                })
                .ToListAsync(),
        };
        return viewmodel;
    }

    public async Task<bool> RestoreCourseViewModelAsync(int id)
    {
        var course = await _dbContext.Courses
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(c => c.Id == id && c.IsDeleted);
        if(course == null) return false;

        course.IsDeleted = false;
        course.DeletedAt = null;
        course.UpdatedAt = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RestoreGradeViewModelAsync(int id)
    {
       var grade = await _dbContext.grades
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(g=>g.Id == id && g.IsDeleted);
        if(grade == null) return false;

        var studentcoursexist = await _dbContext.studentCourses
            .AnyAsync(sc => sc.Id == grade.StudentCourseId);
        if(!studentcoursexist) return false;

        grade.IsDeleted = false;
        grade.DeletedAt = null;
        grade.UpdatedAt = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RestoreStudentCourseViewModelAsync(int id)
    {
        var studentcourse = await _dbContext.studentCourses
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(sc=>sc.Id == id && sc.IsDeleted);

        if(studentcourse == null) return false;

        var studentexist = await _dbContext.Students
            .AnyAsync(s=>s.Id == studentcourse.StudentId);

        var courseexist = await _dbContext.Courses
            .AnyAsync(c=>c.Id == studentcourse.CourseId);

        if(!courseexist || !studentexist) return true;

        studentcourse.IsDeleted = false;
        studentcourse.DeletedAt = null;
        studentcourse.UpdatedAt = DateTime.UtcNow;
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RestoreStudentViewModelAsync(int id)
    {
        var student = await _dbContext.Students
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(s=>s.Id == id && s.IsDeleted);
        if(student == null) return false;
        
        student.IsDeleted = false;
        student.DeletedAt = null;
        student.UpdatedAt = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync();
        return true;
    }
}
