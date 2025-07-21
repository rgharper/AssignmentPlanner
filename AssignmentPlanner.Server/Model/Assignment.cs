using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentPlanner.Server.Model
{
    public class Assignment
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desciption { get; set; }
        public DateTime Date { get; set; }
        public int ClassId { get; set; }

        [ForeignKey("ClassId")]
        public Class Class { get; set; }
}
}
