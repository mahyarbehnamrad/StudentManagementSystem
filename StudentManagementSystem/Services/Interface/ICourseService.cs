using StudentManagementSystem.Models.Entities;
using StudentManagementSystem.Models.ViewModels.Courses;

namespace StudentManagementSystem.Services.Interface;

public interface ICourseService
{
    Task CreateAsync(CreateCourseViewModel viewModel);
    Task<bool> SoftDeleteAsync(int id);
    Task<bool> UpdateAsync(EditCourseViewModel viewModel);
    Task<List<ListCourseViewModel>> GetAllAsync();
    Task<DetailCourseViewModel?> GetByIdAsync(int id);
    Task <EditCourseViewModel?> GetForEditAsync(int id);
    Task<DeleteCourseViewModel?> GetForDeleteAsync(int id);

}
