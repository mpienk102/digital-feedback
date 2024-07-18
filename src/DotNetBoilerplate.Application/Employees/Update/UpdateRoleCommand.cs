using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Shared.Abstractions.Commands;

namespace DotNetBoilerplate.Application.Employees.Update
{
    public sealed record UpdateRoleCommand(Guid UserId, Guid OrganizationId, RoleInOrganization.Role NewRole) : ICommand;
}