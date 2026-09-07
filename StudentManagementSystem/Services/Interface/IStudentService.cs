using StudentManagementSystem.Models.Enums;
using StudentManagementSystem.Models.ViewModels.Students;

namespace StudentManagementSystem.Services.Interface;

public interface IStudentService
{
    Task CreateAsync(CreateStudentViewModel model);
    Task<List<ListStudentViewModel>> GetAllAsync(string? searchTerm, StudentStatus? status);
    Task<DetailStudentViewModel?> GetByIdAsync(int id);
    Task<EditStudentViewModel?> GetForEditAsync(int id);
    Task<bool> UpdateAsync(EditStudentViewModel model);
    Task<bool> SoftDeleteAsync(int id);
    Task<DeleteStudentViewModel?> GetForSoftDeleteAsync(int id);
}
