namespace AssignmentPlanner.Server.DTOs
{
    public class ClassDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public AssignmentDTO[] assignments { get; set; } = [];
    }
}
