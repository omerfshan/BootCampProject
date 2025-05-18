using AutoMapper;
using Business.DTOs;
using Entities.Concrete;

namespace Business.Mappings;

public class BlacklistProfile : Profile
{
    public BlacklistProfile()
    {
        CreateMap<Blacklist, BlacklistDto>()
            .ForMember(dest => dest.ApplicantName, 
                opt => opt.MapFrom(src => $"{src.Applicant.FirstName} {src.Applicant.LastName}"));

        CreateMap<BlacklistCreateDto, Blacklist>();
        CreateMap<BlacklistUpdateDto, Blacklist>();
    }
} 