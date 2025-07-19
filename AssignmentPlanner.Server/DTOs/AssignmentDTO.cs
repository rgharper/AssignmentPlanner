using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace AssignmentPlanner.Server.DTOs
{
    public class AssignmentDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public int ClassId { get; set; }
        public bool Completed { get; set; }
    }
}
