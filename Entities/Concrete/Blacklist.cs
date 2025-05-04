using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete;

public class Blacklist : IEntity
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(500)]
    public string Reason { get; set; } = null!;
    
    [Required]
    public DateTime Date { get; set; }
    
    [Required]
    public int ApplicantId { get; set; }

    // Navigation property
    public virtual Applicant Applicant { get; set; } = null!;
} 