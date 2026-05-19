namespace LMS.Application.Features.Enrollments.DTOs
{
    public class EnrollmentDto
    {
        public int EnrollmentId { get; set; }

        public int UserId { get; set; }

        public int CourseId { get; set; }

        public DateTime EnrolledAt { get; set; }
    }
}