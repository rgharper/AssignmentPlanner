using AutoMapper;
namespace AssignmentPlanner.Server.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Model.Class, DTOs.ClassDTO>()
                .ForMember(dest => dest.Assignments, opt => opt.MapFrom(src => src.Assignments));
            CreateMap<DTOs.ClassDTO, Model.Class>();
            CreateMap<Model.Assignment, DTOs.AssignmentDTO>();
            CreateMap<DTOs.AssignmentDTO, Model.Assignment>();
        }
    }
}
