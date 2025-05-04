using Core.Entities;
using Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete;

public class Bootcamp : IEntity
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = null!;
    
    [Required]
    public int InstructorId { get; set; }
    
    [Required]
    public DateTime StartDate { get; set; }
    
    [Required]
    public DateTime EndDate { get; set; }
    
    [Required]
    public BootcampState State { get; set; }

    // Navigation properties
    public virtual Instructor Instructor { get; set; } = null!;
    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
} 