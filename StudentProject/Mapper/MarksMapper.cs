using AutoMapper;
using StudentProject.Dto;
using StudentProject.Models;

namespace StudentProject.Mapper
{
    public class MarksMapper : Profile
    {
        public MarksMapper()
        {
            CreateMap<StudentVM, Marks>()
                .ForMember(dest => dest.Id, opt => opt
                .MapFrom(src => src.MarksId))
                .ReverseMap();

        }
    }
}
