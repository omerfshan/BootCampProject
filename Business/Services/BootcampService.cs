using AutoMapper;
using Business.DTOs;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Services;

public class BootcampService : IBootcampService
{
    private readonly IBootcampRepository _bootcampRepository;
    private readonly IMapper _mapper;

    public BootcampService(IBootcampRepository bootcampRepository, IMapper mapper)
    {
        _bootcampRepository = bootcampRepository;
        _mapper = mapper;
    }

    public async Task<BootcampDto> GetByIdAsync(int id)
    {
        var bootcamp = await _bootcampRepository.GetAsync(b => b.Id == id);
        return _mapper.Map<BootcampDto>(bootcamp);
    }

    public async Task<IEnumerable<BootcampDto>> GetAllAsync()
    {
        var bootcamps = await _bootcampRepository.GetListAsync();
        return _mapper.Map<IEnumerable<BootcampDto>>(bootcamps);
    }

    public async Task<BootcampDto> CreateAsync(BootcampCreateDto createDto)
    {
        var bootcamp = _mapper.Map<Bootcamp>(createDto);
        bootcamp.State = BootcampState.PREPARING;
        await _bootcampRepository.AddAsync(bootcamp);
        return _mapper.Map<BootcampDto>(bootcamp);
    }

    public async Task<BootcampDto> UpdateAsync(int id, BootcampUpdateDto updateDto)
    {
        var bootcamp = await _bootcampRepository.GetAsync(b => b.Id == id);
        _mapper.Map(updateDto, bootcamp);
        await _bootcampRepository.UpdateAsync(bootcamp);
        return _mapper.Map<BootcampDto>(bootcamp);
    }

    public async Task DeleteAsync(int id)
    {
        var bootcamp = await _bootcampRepository.GetAsync(b => b.Id == id);
        await _bootcampRepository.DeleteAsync(bootcamp);
    }
} 