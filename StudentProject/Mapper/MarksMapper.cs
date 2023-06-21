using AutoMapper;
using StudentProject.Dto;
using StudentProject.Models;

namespace StudentProject.Mapper
{
    public class MarksMapper : Profile
    {
        public MarksMapper()
        {
            CreateMap<MarkDto, Marks>().ReverseMap();

        }
    }
}
