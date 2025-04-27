using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete;

public class Instructor : User
{
    [Required]
    [StringLength(100)]
    public string CompanyName { get; set; } = null!;
} 