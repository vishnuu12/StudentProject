using AutoMapper;
using StudentProject.Dto;
using StudentProject.Models;

namespace StudentProject.Mapper
{
    public class StudentMapper : Profile
    {
        public StudentMapper()
        {
            CreateMap<StudentDto, Student>()
                .ForMember(dest => dest.DOB, opt => opt
                .MapFrom(src => src.DateOfBirth))
                .ReverseMap();

        }
    }
}
