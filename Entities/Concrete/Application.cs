using Core.Entities;
using Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete;

public class Application : IEntity
{
    public int Id { get; set; }
    
    [Required]
    public int ApplicantId { get; set; }
    
    [Required]
    public int BootcampId { get; set; }
    
    [Required]
    public ApplicationState State { get; set; }

    // Navigation properties
    public virtual Applicant Applicant { get; set; } = null!;
    public virtual Bootcamp Bootcamp { get; set; } = null!;
} 