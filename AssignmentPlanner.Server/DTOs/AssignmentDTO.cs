using AssignmentPlanner.Server.Model;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentPlanner.Server.DTOs
{
    public class AssignmentDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desciption { get; set; }
        public DateTime Date { get; set; }
        public int ClassId { get; set; }
    }
}
