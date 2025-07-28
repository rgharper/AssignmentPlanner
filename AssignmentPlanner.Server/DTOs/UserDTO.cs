namespace AssignmentPlanner.Server.DTOs
{
    public class UserDTO
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public IEnumerable<ClassDTO>? Classes { get; set; }
        public string? Token { get; set; } // JWT Token for authentication
    }
}
