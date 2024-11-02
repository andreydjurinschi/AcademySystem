using Academy.Services.CourseAPI.Models;
using AutoMapper;

namespace Academy.Services.CourseAPI.Configurations
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<Course, CourseDto>();
            CreateMap<CourseDto, Course>();
        }
    }
}
