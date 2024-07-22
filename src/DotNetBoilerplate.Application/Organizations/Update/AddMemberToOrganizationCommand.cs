using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Core.Employees;

namespace DotNetBoilerplate.Application.Organizations.Update
{
    public sealed record AddMemberToOrganizationCommand(Guid EmployeeId, Guid OrganizationId, RoleInOrganization.Role Role) : ICommand<Guid>;
}
