namespace Api.Domain.Interfaces;

public interface IURLShortener
{
    string Shorten(string originalURL);
}