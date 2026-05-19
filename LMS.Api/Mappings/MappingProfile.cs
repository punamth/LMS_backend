using AutoMapper;
using LMS.Domain.Entities;
using LMS.Application.Features.Auth.DTOs;
using LMS.Application.Features.Auth.Commands;
using LMS.Application.Features.Courses.DTOs;
using LMS.Application.Features.Enrollments.DTOs;
using LMS.Application.Features.Courses.Commands;
using LMS.Application.Features.Lessons.Commands;
using LMS.Application.Features.Lessons.DTOs;
using LMS.Application.Features.Enrollment.Commands;
using LMS.Application.Features.Progress.Commands;
using LMS.Application.Features.Progress.DTOs;
using LMS.Application.Features.Tests.Commands;
using LMS.Application.Features.Tests.DTOs;

namespace LMS.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User mappings
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<RegisterUserCommand, User>();

            // Course mappings
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<CreateCourseCommand, Course>();

            // Lesson mappings
            CreateMap<Lesson, LessonDto>().ReverseMap();
            CreateMap<CreateLessonCommand, Lesson>();

            // Enrollment mappings
            CreateMap<Enrollment, EnrollmentDto>().ReverseMap();
            CreateMap<EnrollCourseCommand, Enrollment>();

            // Progress mappings
            CreateMap<Progress, ProgressDto>().ReverseMap();
            CreateMap<UpdateProgressCommand, Progress>();

            // Test mappings
            CreateMap<Test, TestDto>().ReverseMap();
            CreateMap<SubmitTestCommand, TestAttempt>();
        }
    }
}
