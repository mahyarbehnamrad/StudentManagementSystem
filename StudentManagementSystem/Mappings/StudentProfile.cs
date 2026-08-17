using AutoMapper;
using StudentManagementSystem.Models.Entities;
using StudentManagementSystem.Models.ViewModels.Students;

namespace StudentManagementSystem.Mappings;

public class StudentProfile : Profile
{
    public StudentProfile()
    {
        CreateMap<CreateStudentViewModel, Student>();
        CreateProjection<Student, ListStudentViewModel>()
            .ForMember(
            dest => dest.FullName,
            opt => opt.MapFrom(src => src.Name + " " + src.Family));
        CreateProjection<Student, DetailsStudentViewModel>()
            .ForMember(
            dest => dest.FullName,
            opt => opt.MapFrom(src => src.Name + " " + src.Family));
        CreateMap<EditStudentViewModel, Student>().ReverseMap();
        CreateProjection<Student, DeleteStudentViewModel>()
            .ForMember(
            dest => dest.FullName,
            opt => opt.MapFrom(src => src.Name + " " + src.Family));
    }
}