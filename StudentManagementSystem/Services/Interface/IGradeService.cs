using StudentManagementSystem.Models.ViewModels.Grades;

namespace StudentManagementSystem.Services.Interface;

public interface IGradeService
{
    Task<bool> CreateAsync(CreateGradeViewModel viewModel);
    Task<bool> UpdateAsync(EditGradeViewModel viewModel);
    Task<bool> SoftDeleteAsync(int id);
    Task<List<ListGradeViewModel>> GetAllAsync(); 
    Task<CreateGradeViewModel> GetForCreateModelAsync();
    Task<DeleteGradeViewModel?> GetForSoftDeleteAsync(int id);
    Task<EditGradeViewModel?> GetForEditModelAsync(int id);
}
