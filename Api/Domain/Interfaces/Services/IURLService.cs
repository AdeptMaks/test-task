using Api.Domain.Models.DTOs;
using Api.Domain.Models.Entities;
using Api.Domain.Models.Utils;

namespace Api.Domain.Interfaces.Services;

public interface IURLService
{
    Task<Response<URL>> ShortenURLAsync(URLCreateRequest request, string userId);
    Task<Response<List<URLShortResponse>>> GetAllURLsAsync(string userId);


}