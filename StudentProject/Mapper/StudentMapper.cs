using AutoMapper;
using StudentProject.Dto;
using StudentProject.Models;

namespace StudentProject.Mapper
{
    public class StudentMapper : Profile
    {
        public StudentMapper()
        {
            CreateMap<StudentVM, Student>()
                .ForMember(dest => dest.DOB, opt => opt
                .MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.Id, opt => opt
                .MapFrom(src => src.StudentId))
                .ReverseMap();

        }
    }
}
