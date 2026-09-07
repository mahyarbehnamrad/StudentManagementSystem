using StudentManagementSystem.Models.ViewModels.RecycleBin;

namespace StudentManagementSystem.Services.Interface;

public interface IRecycleBinRestoreService
{
    Task<RecycleBinViewModel> GetAllAsync();
    Task<bool> RestoreStudentViewModelAsync(int id);
    Task<bool> RestoreCourseViewModelAsync(int id);
    Task<bool> RestoreStudentCourseViewModelAsync(int id);
    Task<bool> RestoreGradeViewModelAsync(int id);
}
