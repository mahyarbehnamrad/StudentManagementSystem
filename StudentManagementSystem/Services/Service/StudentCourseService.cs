using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Migrations;
using StudentManagementSystem.Models.Data;
using StudentManagementSystem.Models.Entities;
using StudentManagementSystem.Models.ViewModels.StudentCourses;
using StudentManagementSystem.Services.Interface;

namespace StudentManagementSystem.Services.Service;

public class StudentCourseService : IStudentCourseService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public StudentCourseService(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public async Task<bool> CreateAsync(CreateStudentCourseViewModel viewModel)
    {
        var studentExist = await _dbContext.Students.AnyAsync(s => s.Id == viewModel.StudentId);
        var courseExist = await _dbContext.Courses.AnyAsync(c => c.Id == viewModel.CourseId);
        if (!studentExist || !courseExist) return false;
        var existingEnrollment = await _dbContext.studentCourses.IgnoreQueryFilters().FirstOrDefaultAsync(sc => sc.StudentId == viewModel.StudentId && sc.CourseId == viewModel.CourseId);
        if (existingEnrollment != null)
        {
            if (!existingEnrollment.IsDeleted)
                return false;
            existingEnrollment.IsDeleted = false;
            existingEnrollment.DeletedAt = null;
            existingEnrollment.UpdatedAt = DateTime.UtcNow;
            await _dbContext.SaveChangesAsync();
            return true;
        }
        var studentcourse = new StudentCourseEntity
        {
            StudentId = viewModel.StudentId,
            CourseId = viewModel.CourseId,
            CreatedAt = DateTime.UtcNow
        };
        _dbContext.studentCourses.Add(studentcourse);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<DeleteStudentCourseViewModel?> GetForDeleteAsync(int id)
    {
        return await _dbContext.studentCourses
            .AsNoTracking()
            .Where(c => c.Id == id)
            .ProjectTo<DeleteStudentCourseViewModel>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();
    }

    public async Task<List<ListStudentCourseViewModel>> GetAllAsync()
    {
        return await _dbContext.studentCourses
            .AsNoTracking()
            .OrderBy(c => c.Student.Name)
            .ProjectTo<ListStudentCourseViewModel>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<CreateStudentCourseViewModel> GetCreateModelAsync()
    {
        var viewModel = new CreateStudentCourseViewModel
        {
            Students = await _dbContext.Students
            .AsNoTracking()
            .OrderBy(c => c.Name)
            .Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name + " " + s.Family
            })
            .ToListAsync(),


            Courses = await _dbContext.Courses
            .AsNoTracking()
            .OrderBy(c => c.Name)
            .Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name
            })
            .ToListAsync()
        };
        return viewModel;
    }

    public async Task<bool> SoftDeleteAsync(int id)
    {
        var studentcourse = await _dbContext.studentCourses.FirstOrDefaultAsync(src=>src.Id == id);
        if(studentcourse == null) return false;
        studentcourse.IsDeleted = true;
        studentcourse.DeletedAt = DateTime.UtcNow;
        studentcourse.UpdatedAt = DateTime.UtcNow;
        await _dbContext.SaveChangesAsync();
        return true;
    }
}
