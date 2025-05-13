namespace Business.DTOs;

public class BlacklistDto
{
    public int Id { get; set; }
    public string ApplicantName { get; set; } = null!;
    public string Reason { get; set; } = null!;
    public DateTime Date { get; set; }
}

public class BlacklistCreateDto
{
    public int ApplicantId { get; set; }
    public string Reason { get; set; } = null!;
}

public class BlacklistUpdateDto
{
    public string Reason { get; set; } = null!;
} 