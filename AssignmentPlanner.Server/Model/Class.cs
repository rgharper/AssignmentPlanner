using System.ComponentModel.DataAnnotations;

namespace AssignmentPlanner.Server.Model
{
    public class Class
    {
        [Key]
        public int Id { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public IEnumerable<Assignment> Assignments { get; set; } = new List<Assignment>();
        public List<User> Users { get; } = [];
    }
}
