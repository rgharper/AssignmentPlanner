using AssignmentPlanner.Server.DTOs;

namespace AssignmentPlanner.Server.Services
{
    public class ClassService
    {
        public List<ClassDTO> GetClasses(int? userid)
        {
            var classes = new List<ClassDTO>();
            for (int i = 0; i < 5; i++)
            {
                classes.Add(new ClassDTO
                {
                    id = i,
                    name = $"Class {i}",
                    assignments = new AssignmentDTO[]
                    {
                        new() {
                            Id = i,
                            Title = $"Assignment {i}",
                            Description = $"Description for assignment {i}",
                            DueDate = DateTime.Now.AddDays(i),
                            ClassId = i,
                            Completed = false
                        }
                    }
                });
            }
            return classes;
        }
    }
}
