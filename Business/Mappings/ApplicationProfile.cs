using AutoMapper;
using Business.DTOs;
using Entities.Concrete;
using Entities.Enums;

namespace Business.Mappings;

public class ApplicationProfile : Profile
{
    public ApplicationProfile()
    {
        CreateMap<Application, ApplicationDto>()
            .ForMember(dest => dest.ApplicantName, 
                opt => opt.MapFrom(src => $"{src.Applicant.FirstName} {src.Applicant.LastName}"))
            .ForMember(dest => dest.BootcampName, 
                opt => opt.MapFrom(src => src.Bootcamp.Name));

        CreateMap<ApplicationCreateDto, Application>();
        CreateMap<ApplicationUpdateDto, Application>();
    }
} 