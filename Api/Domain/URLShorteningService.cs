using Api.Domain.Interfaces;

namespace Api.Domain;

public class URLShorteningService : IURLShortener
{
    public string Shorten(string originalURL)
    {
        var hash = originalURL.GetHashCode().ToString("X");
        return hash[..6];
    }

}