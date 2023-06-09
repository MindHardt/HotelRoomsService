namespace Core.Services.DI;

/// <summary>
/// Specifies that decorated class is a service and should be injected.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class DefaultServiceAttribute : Attribute
{ }