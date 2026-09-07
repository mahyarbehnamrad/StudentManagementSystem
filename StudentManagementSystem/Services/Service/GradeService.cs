using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models.Data;
using StudentManagementSystem.Models.Entities;
using StudentManagementSystem.Models.ViewModels.Grades;
using StudentManagementSystem.Services.Interface;

namespace StudentManagementSystem.Services.Service;

public class GradeService : IGradeService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GradeService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<bool> CreateAsync(CreateGradeViewModel viewModel)
    {
        var Enrollment = await _context.studentCourses.Include(x => x.Course).FirstOrDefaultAsync(x => x.Id == viewModel.StudentCourseId);
        if (Enrollment == null) return false;
        if (viewModel.Score < 0 || viewModel.Score > Enrollment.Course.MaxGrade) return false;
        var ExistingGrade = await _context.grades.IgnoreQueryFilters().FirstOrDefaultAsync(x => x.StudentCourseId == viewModel.StudentCourseId);
        if (ExistingGrade != null)
        {
            if (!ExistingGrade.IsDeleted) return false;

            ExistingGrade.Score = viewModel.Score;
            ExistingGrade.IsDeleted = false;
            ExistingGrade.DeletedAt = null;
            ExistingGrade.UpdatedAt = DateTime.UtcNow;
        }
        var grade = new GradeEntity
        {
            StudentCourseId = viewModel.StudentCourseId,
            Score = viewModel.Score,
            CreatedAt = DateTime.UtcNow,
        };
        _context.grades.Add(grade);
        await _context.SaveChangesAsync();
        return true;

    }

    public async Task<List<ListGradeViewModel>> GetAllAsync(string? searchTerm, int? courseId)
    {
        var query = _context.grades
            .AsNoTracking()
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            searchTerm = searchTerm.Trim();

            query = query.Where(g =>
                g.studentCourse.Student.Name.Contains(searchTerm) ||
                g.studentCourse.Student.Family.Contains(searchTerm) ||
                (g.studentCourse.Student.Name + " " +
                 g.studentCourse.Student.Family)
                    .Contains(searchTerm));
        }

        if (courseId.HasValue)
        {
            query = query.Where(g =>
                g.studentCourse.CourseId == courseId.Value);
        }

        return await query
            .OrderBy(g => g.studentCourse.Student.Name)
            .ProjectTo<ListGradeViewModel>(
                _mapper.ConfigurationProvider)
            .ToListAsync();
    }
    public async Task<List<SelectListItem>> GetCourseOptionsAsync()
    {
        return await _context.Courses
            .AsNoTracking()
            .OrderBy(c => c.Name)
            .Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            })
            .ToListAsync();
    }

    public async Task<CreateGradeViewModel> GetForCreateModelAsync()
    {
        var viewModel = new CreateGradeViewModel
        {
            Enrollments = await _context.studentCourses
            .AsNoTracking()
            .Where(sc => !_context.grades.Any(g => g.StudentCourseId == sc.Id))
            .OrderBy(sc => sc.Student.Name)
            .Select(sc => new SelectListItem
            {
                Value = sc.Id.ToString(),
                Text = sc.Student.Name + " " + sc.Student.Family + " - " + sc.Course.Name
            })
            .ToListAsync()
        };
        return viewModel;
    }

    public async Task<EditGradeViewModel?> GetForEditModelAsync(int id)
    {
        return await _context.grades.AsNoTracking().Where(x=> x.Id == id).ProjectTo<EditGradeViewModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
    }

    public async Task<DeleteGradeViewModel?> GetForSoftDeleteAsync(int id)
    {
        return await _context.grades.AsNoTracking().Where(x => x.Id == id).ProjectTo<DeleteGradeViewModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
    }

    public async Task<bool> SoftDeleteAsync(int id)
    {
        var grade = await _context.grades.FirstOrDefaultAsync(x => x.Id == id);
        if (grade == null) return false;

        grade.IsDeleted = true;
        grade.DeletedAt = DateTime.UtcNow;
        grade.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(EditGradeViewModel viewModel)
    {
        var grade = await _context.grades.Include(x => x.studentCourse).ThenInclude(x => x.Course).FirstOrDefaultAsync(x => x.Id == viewModel.Id);
        if (grade == null) return false;
        if (viewModel.Score < 0 || viewModel.Score > grade.studentCourse.Course.MaxGrade) return false;
        grade.Score = viewModel.Score;
        grade.UpdatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();
        return true;
    }
}
