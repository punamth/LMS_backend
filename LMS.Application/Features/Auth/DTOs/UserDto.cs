namespace LMS.Application.Features.Auth.DTOs
{
    public class UserDto
    {
        public int UserId { get; set; }

        public required string UserName { get; set; }

        public required string Email { get; set; }

        public required UserRole Role { get; set; }
    }
    public enum UserRole
    {
        Student,
        Admin
    }
}