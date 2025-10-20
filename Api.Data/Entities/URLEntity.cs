using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Data.Entities;

public class URLEntity
{
    public Guid Id { get; set; }
    public string OriginalURL { get; set; } = null!;
    public string ShortenedURL { get; set; } = null!;
    [Column("CreatedBy")]
    public Guid UserId { get; set; }
    public BaseUser User { get; set; } 
    public DateTime CreatedAt { get; set; }
}