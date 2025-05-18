using Entities.Concrete;
using Entities.Enums;

namespace Business.DTOs;

public class BootcampDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string InstructorName { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public BootcampState State { get; set; }
    public int ApplicationCount { get; set; }
}

public class BootcampCreateDto
{
    public string Name { get; set; } = null!;
    public int InstructorId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}

public class BootcampUpdateDto
{
    public string Name { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public BootcampState State { get; set; }
} 