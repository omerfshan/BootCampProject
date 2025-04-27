using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class User : IEntity
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public string Username { get; set; } = null!;
    
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = null!;
    
    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = null!;
    
    public DateTime DateOfBirth { get; set; }
    
    [Required]
    [StringLength(11)]
    public string NationalIdentity { get; set; } = null!;
    
    [Required]
    [EmailAddress]
    [StringLength(100)]
    public string Email { get; set; } = null!;
    
    [Required]
    [StringLength(100)]
    public string Password { get; set; } = null!;
} 