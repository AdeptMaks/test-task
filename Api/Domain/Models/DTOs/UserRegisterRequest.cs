namespace Api.Domain.Models.DTOs;

public record UserRegisterRequest(string Login, string Password, string PasswordConfirmation);