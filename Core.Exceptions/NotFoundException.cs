using System.Diagnostics.CodeAnalysis;

namespace Core.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string? message) : base(message)
    {
    }

    public static void ThrowIfNull([NotNull] object? param, string? message = null)
    {
        if (param is null)
            throw new NotFoundException(message);
    }
}