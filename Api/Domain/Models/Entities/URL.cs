namespace Api.Domain.Models.Entities;

public class URL
{
    public Guid Id { get; set; }
    public string OriginalURL { get; set; } 
    public string ShortenedURL { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }
}