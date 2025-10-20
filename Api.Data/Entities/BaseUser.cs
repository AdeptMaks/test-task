namespace Api.Data.Entities;

public abstract class BaseUser
{
    public Guid Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}

