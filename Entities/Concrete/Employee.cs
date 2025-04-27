using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete;

public class Employee : User
{
    [Required]
    [StringLength(100)]
    public string Position { get; set; } = null!;
} 