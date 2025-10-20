namespace Api.Domain.Models.Entities;

public abstract class AppBaseUser
{
    public Guid Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}