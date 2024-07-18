using DotNetBoilerplate.Core.Users;
using DotNetBoilerplate.Shared.Abstractions.Exceptions;

namespace DotNetBoilerplate.Application.Exceptions;

public sealed class EmployeeNotFoundException : CustomException
{
    public EmployeeNotFoundException(Guid userId) : base($"User {userId} not found")
    {
    }
}