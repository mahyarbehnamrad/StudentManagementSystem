using AutoMapper;
using StudentManagementSystem.Models.Entities;
using StudentManagementSystem.Models.ViewModels.StudentCourses;

namespace StudentManagementSystem.Mappings;

public class StudentCourseProfile:Profile
{
    public StudentCourseProfile()
    {
        CreateProjection<StudentCourseEntity, ListStudentCourseViewModel>()
            .ForMember(x=>x.StudentName, x=>x.MapFrom(src=>src.Student.Name + " " + src.Student.Family))
            .ForMember(x=>x.CourseName, x=>x.MapFrom(src=>src.Course.Name))
            .ForMember(x=>x.MaxGrade, x=>x.MapFrom(src=>src.Course.MaxGrade));
        CreateProjection<StudentCourseEntity, DeleteStudentCourseViewModel>()
            .ForMember(x=>x.StudentName, x=>x.MapFrom(src=>src.Student.Name + " " + src.Student.Family))
            .ForMember(x=>x.CourseName, x=>x.MapFrom(src => src.Course.Name));
    }
}
