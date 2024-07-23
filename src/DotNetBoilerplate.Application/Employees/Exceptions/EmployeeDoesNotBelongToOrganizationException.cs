using DotNetBoilerplate.Core.Users;
using DotNetBoilerplate.Shared.Abstractions.Exceptions;

namespace DotNetBoilerplate.Application.Employees.Exceptions;

public sealed class EmployeeDoesNotBelongToOrganizationException : CustomException
{
    public EmployeeDoesNotBelongToOrganizationException(Guid organizationId, Guid userId) : base($"User {userId} does not belong to {organizationId} organization!")
    {
    }
}