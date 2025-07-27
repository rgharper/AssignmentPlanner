using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
