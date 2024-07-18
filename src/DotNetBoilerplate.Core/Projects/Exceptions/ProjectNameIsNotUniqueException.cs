using DotNetBoilerplate.Shared.Abstractions.Exceptions;

namespace DotNetBoilerplate.Core.Projects.Exceptions;

public sealed class ProjectNameIsNotUniqueException() : CustomException("Project name is not unique")
{
}