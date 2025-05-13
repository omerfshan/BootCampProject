using Business.DTOs;

namespace Business.Services;

public interface IBootcampService
{
    Task<BootcampDto> GetByIdAsync(int id);
    Task<IEnumerable<BootcampDto>> GetAllAsync();
    Task<BootcampDto> CreateAsync(BootcampCreateDto createDto);
    Task<BootcampDto> UpdateAsync(int id, BootcampUpdateDto updateDto);
    Task DeleteAsync(int id);
} 