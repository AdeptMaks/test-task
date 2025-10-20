namespace Api.Configurations;

public class JwtOptions
{
    public string Key { get; set; }
    public int ExpiresInHours { get; set; }
}