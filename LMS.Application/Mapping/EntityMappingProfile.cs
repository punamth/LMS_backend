using AutoMapper;
using LMS.Application.Features.Courses.DTOs;
using LMS.Application.Features.Lessons.DTOs;
using LMS.Domain.Entities;

namespace LMS.Application.Mapping
{
    public class EntityMappingProfile : Profile
    {
        public EntityMappingProfile()
        {
            CreateMap<Course, CourseDto>();
            CreateMap<Lesson, LessonDto>();
        }
    }
}
