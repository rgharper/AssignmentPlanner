namespace AssignmentPlanner.Server.DTOs
{
    public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Role { get; set; } = 4; // 4 = New User, 3 = Parent, 2 = Student, 1 = Teacher, 0 = Admin
    }
}
