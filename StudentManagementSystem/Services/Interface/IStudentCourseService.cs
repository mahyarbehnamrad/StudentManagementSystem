using StudentManagementSystem.Models.ViewModels.StudentCourses;

namespace StudentManagementSystem.Services.Interface;

public interface IStudentCourseService
{
    Task<CreateStudentCourseViewModel> GetCreateModelAsync();
    Task<bool> CreateAsync(CreateStudentCourseViewModel viewModel);
    Task<List<ListStudentCourseViewModel>> GetAllAsync(string? searchTerm);
    Task<DeleteStudentCourseViewModel?> GetForDeleteAsync(int id);
    Task<bool> SoftDeleteAsync(int id);
}