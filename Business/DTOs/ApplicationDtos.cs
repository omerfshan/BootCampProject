using Entities.Concrete;
using Entities.Enums;

namespace Business.DTOs;

public class ApplicationDto
{
    public int Id { get; set; }
    public string ApplicantName { get; set; } = null!;
    public string BootcampName { get; set; } = null!;
    public ApplicationState State { get; set; }
}

public class ApplicationCreateDto
{
    public int ApplicantId { get; set; }
    public int BootcampId { get; set; }
}

public class ApplicationUpdateDto
{
    public ApplicationState State { get; set; }
} 