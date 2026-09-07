using StudentManagementSystem.Models.ViewModels.Dashboard;

namespace StudentManagementSystem.Services.Interface;

public interface IDashboardService
{
    Task<DashboardViewModel> GetStatisticsAsync();
}
