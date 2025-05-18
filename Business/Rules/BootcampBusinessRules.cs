using Core.Exceptions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Enums;

namespace Business.Rules;

public class BootcampBusinessRules
{
    private readonly IBootcampRepository _bootcampRepository;
    private readonly IInstructorRepository _instructorRepository;

    public BootcampBusinessRules(
        IBootcampRepository bootcampRepository,
        IInstructorRepository instructorRepository)
    {
        _bootcampRepository = bootcampRepository;
        _instructorRepository = instructorRepository;
    }

    public void CheckIfDatesAreValid(DateTime startDate, DateTime endDate)
    {
        if (startDate >= endDate)
            throw new BusinessException("Start date must be before end date.");
    }

    public async Task CheckIfNameExists(string name)
    {
        var bootcamp = await _bootcampRepository.GetAsync(b => b.Name == name);
        if (bootcamp != null)
            throw new BusinessException("A bootcamp with this name already exists.");
    }

    public async Task CheckIfInstructorExists(int instructorId)
    {
        var instructor = await _instructorRepository.GetAsync(i => i.Id == instructorId);
        if (instructor == null)
            throw new NotFoundException("Instructor not found.");
    }

    public async Task CheckIfBootcampIsOpenForApplication(int bootcampId)
    {
        var bootcamp = await _bootcampRepository.GetAsync(b => b.Id == bootcampId);
        if (bootcamp == null)
            throw new NotFoundException("Bootcamp not found.");

        if (bootcamp.State != BootcampState.OPEN_FOR_APPLICATION)
            throw new BusinessException("This bootcamp is not open for applications.");
    }
} 