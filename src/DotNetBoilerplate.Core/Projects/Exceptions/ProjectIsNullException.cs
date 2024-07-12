using DotNetBoilerplate.Shared.Abstractions.Exceptions;

namespace DotNetBoilerplate.Core.Organizations.Exceptions
{
    public sealed class ProjectIsNullException(Guid Id) : CustomException($"Project {Id} not found")
    {

    }
}
