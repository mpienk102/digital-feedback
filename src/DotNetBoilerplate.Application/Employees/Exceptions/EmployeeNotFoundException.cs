using DotNetBoilerplate.Core.Users;
using DotNetBoilerplate.Shared.Abstractions.Exceptions;

namespace DotNetBoilerplate.Application.Employees.Exceptions;

public sealed class EmployeeNotFoundException : CustomException
{
    public EmployeeNotFoundException(Guid userId) : base($"User {userId} not found")
    {
    }
}