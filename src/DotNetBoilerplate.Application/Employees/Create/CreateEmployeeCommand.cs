using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Shared.Abstractions.Commands;

namespace DotNetBoilerplate.Application.Employees.Create
{
    public sealed record CreateEmployeeCommand(Guid UserId, Guid OrganizationId, RoleInOrganization.Role Role) : ICommand<Guid>;
}
