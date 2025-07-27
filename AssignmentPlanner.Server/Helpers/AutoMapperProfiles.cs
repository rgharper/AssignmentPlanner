using AutoMapper;
namespace AssignmentPlanner.Server.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Model.Class, DTOs.ClassDTO>();
            CreateMap<DTOs.ClassDTO, Model.Class>();
            CreateMap<Model.Assignment, DTOs.AssignmentDTO>();
            CreateMap<DTOs.AssignmentDTO, Model.Assignment>();
            CreateMap<Model.User, DTOs.UserDTO>();
            CreateMap<DTOs.UserDTO, Model.User>();
        }
    }
}
