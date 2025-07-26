using System.ComponentModel.DataAnnotations;

namespace AssignmentPlanner.Server.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Hash { get; set; } // Argon2
        public string Email { get; set; }
        public int Role { get; set; } // 4 = New User, 3 = Parent, 2 = Student, 1 = Teacher, 0 = Admin
        public IEnumerable<Class> Classes { get; set; } = new List<Class>();
        public IEnumerable<string> Tokens { get; set; } = new List<string>(); // JWT Tokens for authentication
        public string? RefreshToken { get; set; } // Refresh token
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
