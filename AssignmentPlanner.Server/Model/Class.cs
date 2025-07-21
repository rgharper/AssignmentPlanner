using System.ComponentModel.DataAnnotations;

namespace AssignmentPlanner.Server.Model
{
    public class Class
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Assignment> Assignments { get; set; }
    }
}
