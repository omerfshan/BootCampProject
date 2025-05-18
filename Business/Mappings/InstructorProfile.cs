using AutoMapper;
using Business.DTOs;
using Core.Entities;
using Entities.Concrete;

namespace Business.Mappings;

public class InstructorProfile : Profile
{
    public InstructorProfile()
    {
        CreateMap<Instructor, InstructorDto>();
        CreateMap<InstructorCreateDto, Instructor>();
        CreateMap<InstructorUpdateDto, Instructor>();
    }
} 