using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models.Data;
using StudentManagementSystem.Models.Entities;
using StudentManagementSystem.Models.ViewModels.Courses;
using StudentManagementSystem.Models.ViewModels.Students;
using StudentManagementSystem.Services.Interface;

namespace StudentManagementSystem.Services.Service;

public class CourseService : ICourseService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public CourseService(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public async Task CreateAsync(CreateCourseViewModel viewModel)
    {
        var course = _mapper.Map<CourseEntity>(viewModel);
        course.CreatedAt = DateTime.UtcNow;
        _dbContext.Courses.Add(course);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<DeleteCourseViewModel?> GetForDeleteAsync(int id)
    {
        return await _dbContext.Courses
        .AsNoTracking()
        .Where(c => c.Id == id)
        .ProjectTo<DeleteCourseViewModel>(_mapper.ConfigurationProvider)
        .FirstOrDefaultAsync();
    }

    public async Task<EditCourseViewModel?> GetForEditAsync(int id)
    {
        return await _dbContext.Courses
        .AsNoTracking()
        .Where(c => c.Id == id)
        .ProjectTo<EditCourseViewModel>(_mapper.ConfigurationProvider)
        .FirstOrDefaultAsync();
    }

    public async Task<bool> SoftDeleteAsync(int id)
    {
        var course = await _dbContext.Courses.FindAsync(id);
        if(course == null) return false;
        course.IsDeleted = true;
        course.DeletedAt = DateTime.UtcNow;
        course.UpdatedAt = DateTime.UtcNow;
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(EditCourseViewModel viewModel)
    {
        var course = await _dbContext.Courses.FirstOrDefaultAsync(x=>x.Id == viewModel.Id);
        if(course == null) return false;
        _mapper.Map(viewModel, course);
        course.UpdatedAt = DateTime.UtcNow;
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<ListCourseViewModel>> GetAllAsync()
    {
        return await _dbContext.Courses.AsNoTracking().ProjectTo<ListCourseViewModel>(_mapper.ConfigurationProvider).ToListAsync();
    }

    public async Task<DetailCourseViewModel?> GetByIdAsync(int id)
    {
        return await _dbContext.Courses
            .AsNoTracking()
            .Where(c => c.Id == id)
            .ProjectTo<DetailCourseViewModel>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();
    }
}
