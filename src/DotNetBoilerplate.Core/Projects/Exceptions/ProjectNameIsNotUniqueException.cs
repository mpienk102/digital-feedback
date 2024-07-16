using DotNetBoilerplate.Shared.Abstractions.Exceptions;

namespace DotNetBoilerplate.Core.Organizations.Exceptions
{
    public sealed class ProjectNameIsNotUniqueException() : CustomException($"Project name is not unique")
    {

    }
}
