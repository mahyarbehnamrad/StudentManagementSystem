using AutoMapper;
using StudentManagementSystem.Models.Entities;
using StudentManagementSystem.Models.ViewModels.Students;

namespace StudentManagementSystem.Mappings;

public class StudentProfile : Profile
{
    public StudentProfile()
    {
        CreateMap<CreateStudentViewModel, StudentEntity>();
        CreateProjection<StudentEntity, ListStudentViewModel>()
            .ForMember(
            dest => dest.FullName,
            opt => opt.MapFrom(src => src.Name + " " + src.Family));
        CreateProjection<StudentEntity, DetailStudentViewModel>()
            .ForMember(
            dest => dest.FullName,
            opt => opt.MapFrom(src => src.Name + " " + src.Family));
        CreateMap<EditStudentViewModel, StudentEntity>().ReverseMap();
        CreateProjection<StudentEntity, DeleteStudentViewModel>()
            .ForMember(
            dest => dest.FullName,
            opt => opt.MapFrom(src => src.Name + " " + src.Family));
    }
}