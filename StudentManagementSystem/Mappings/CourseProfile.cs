using AutoMapper;
using StudentManagementSystem.Models.Entities;
using StudentManagementSystem.Models.ViewModels.Courses;

namespace StudentManagementSystem.Mappings;

public class CourseProfile:Profile
{
    public CourseProfile()
    {
        CreateMap<CreateCourseViewModel, CourseEntity>();
        CreateMap<EditCourseViewModel, CourseEntity>().ReverseMap();
        CreateProjection<CourseEntity, DetailCourseViewModel>();
        CreateProjection<CourseEntity, ListCourseViewModel>();
        CreateProjection<CourseEntity, DeleteCourseViewModel>();
    }
}
