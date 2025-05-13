using AutoMapper;
using Entities.Concrete;
using Entities.Enums;

namespace Business.Mappings;

public class BootcampProfile : Profile
{
    public BootcampProfile()
    {
        CreateMap<Bootcamp, BootcampDto>()
            .ForMember(dest => dest.InstructorName, 
                opt => opt.MapFrom(src => $"{src.Instructor.FirstName} {src.Instructor.LastName}"))
            .ForMember(dest => dest.ApplicationCount, 
                opt => opt.MapFrom(src => src.Applications.Count));

        CreateMap<BootcampCreateDto, Bootcamp>();
        CreateMap<BootcampUpdateDto, Bootcamp>();
    }
} 