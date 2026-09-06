using AutoMapper;
using StudentManagementSystem.Models.Entities;
using StudentManagementSystem.Models.ViewModels.Grades;

namespace StudentManagementSystem.Mappings;

public class GradeProfile:Profile
{
    public GradeProfile()
    {
        CreateProjection<GradeEntity, ListGradeViewModel>()
            .ForMember(x => x.StudentName, x => x.MapFrom(src => src.studentCourse.Student.Name + " " + src.studentCourse.Student.Family))
            .ForMember(x => x.CourseName, x => x.MapFrom(src => src.studentCourse.Course.Name))
            .ForMember(x => x.MaxGrade, x => x.MapFrom(src => src.studentCourse.Course.MaxGrade))
            .ForMember(x => x.Percentage, x => x.MapFrom(src => src.studentCourse.Course.MaxGrade == 0 ? 0 : (src.Score / src.studentCourse.Course.MaxGrade) * 100));
        CreateProjection<GradeEntity, EditGradeViewModel>()
            .ForMember(x => x.StudentName, x => x.MapFrom(src => src.studentCourse.Student.Name + " " + src.studentCourse.Student.Family))
            .ForMember(x => x.CourseName, x => x.MapFrom(src => src.studentCourse.Course.Name))
            .ForMember(x => x.CourseName, x => x.MapFrom(src => src.studentCourse.Course.MaxGrade));
        CreateProjection<GradeEntity, DeleteGradeViewModel>()
            .ForMember(x => x.StudentName, x => x.MapFrom(src => src.studentCourse.Student.Name + " " + src.studentCourse.Student.Family))
            .ForMember(x => x.CourseName, x => x.MapFrom(src => src.studentCourse.Course.Name));
    }
}
