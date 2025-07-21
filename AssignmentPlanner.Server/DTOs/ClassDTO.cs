using AssignmentPlanner.Server.Model;
using System.ComponentModel.DataAnnotations;

namespace AssignmentPlanner.Server.DTOs
{
    public class ClassDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<AssignmentDTO>? Assignments { get; set; }
    }
}
