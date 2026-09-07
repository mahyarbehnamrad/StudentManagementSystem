namespace StudentManagementSystem.Models.ViewModels.RecycleBin;

public class RecycleBinViewModel
{
    public List<DeletedStudentViewModel> Students { get; set; } = new List<DeletedStudentViewModel>();
    public List<DeletedCourseViewModel> Courses { get; set; } = new List<DeletedCourseViewModel>();
    public List<DeletedGradeViewModel> Grades { get; set; } = new List<DeletedGradeViewModel>();
    public List<DeletedStudentCourseViewModel> StudentCourses { get; set; } = new List<DeletedStudentCourseViewModel>();
}
