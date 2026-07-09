namespace ProductivityPlatform.Api.Models;

public class NotFoundException : Exception
{
    public NotFoundException(string resource, string identifier)
        : base($"Resource '{resource}' with identifier '{identifier}' was not found.")
    {
        Resource = resource;
        Identifier = identifier;
    }

    public string Resource { get; }
    public string Identifier { get; }
}

public class BadRequestException : Exception
{
    public BadRequestException(string message)
        : base(message)
    {
    }

    public BadRequestException(string message, object details)
        : base(message)
    {
        Details = details;
    }

    public object? Details { get; }
}
