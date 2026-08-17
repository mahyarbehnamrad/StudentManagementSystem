using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Mappings;
using StudentManagementSystem.Models.Data;
using StudentManagementSystem.Models.Entities;
using StudentManagementSystem.Models.ViewModels.Students;
using StudentManagementSystem.Services.Interface;

namespace StudentManagementSystem.Services.Service;

public class StudentService : IStudentService
{
    private readonly ApplicationDbContext _contex;
    private readonly IMapper _mapper;
    public StudentService(ApplicationDbContext contex, IMapper mapper)
    {
        _contex = contex;    
        _mapper = mapper;
    }
    public async Task CreateAsync(CreateStudentViewModel model)
    {
        var student = _mapper.Map<Student>(model);
        student.CreatedAt = DateTime.UtcNow;
        _contex.Students.Add(student);
        await _contex.SaveChangesAsync();
    }

    public async Task<bool> SoftDeleteAsync(int id)
    {
        var student = await _contex.Students.FindAsync(id);
        if(student == null) return false;
        student.IsDeleted = true;
        student.DeletedAt = DateTime.UtcNow;
        student.UpdatedAt = DateTime.UtcNow;
        await _contex.SaveChangesAsync();
        return true;
    }

    public async Task<List<ListStudentViewModel>> GetAllAsync()
    {
        return await _contex.Students.AsNoTracking().ProjectTo<ListStudentViewModel>(_mapper.ConfigurationProvider).ToListAsync();
    }

    public async Task<DetailsStudentViewModel?> GetByIdAsync(int id)
    {
        return await _contex.Students
            .AsNoTracking()
            .Where(s => s.Id == id)
            .ProjectTo<DetailsStudentViewModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
    }

    public async Task<DeleteStudentViewModel?> GetForSoftDeleteAsync(int id)
    {
        return await _contex.Students
        .AsNoTracking()
        .Where(s => s.Id == id)
        .ProjectTo<DeleteStudentViewModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
    }

    public async Task<EditStudentViewModel?> GetForEditAsync(int id)
    {
        return await _contex.Students
        .AsNoTracking()
        .Where(s => s.Id == id)
        .ProjectTo<EditStudentViewModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
    }

    public async Task<bool> UpdateAsync(EditStudentViewModel model)
    {
        var student = await _contex.Students.FirstOrDefaultAsync(s=>s.Id == model.Id);
        if(student == null) return false;
        _mapper.Map(model, student);
        student.UpdatedAt = DateTime.UtcNow;
        await _contex.SaveChangesAsync();
        return true;
    }
}
