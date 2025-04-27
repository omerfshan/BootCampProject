using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete;

public class Applicant : User
{
    [Required]
    [StringLength(500)]
    public string About { get; set; } = null!;
} 