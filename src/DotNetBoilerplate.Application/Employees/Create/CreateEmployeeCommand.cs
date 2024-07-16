using DotNetBoilerplate.Shared.Abstractions.Commands;
using static DotNetBoilerplate.Core.Employees.Role;

namespace DotNetBoilerplate.Application.Employees.Create;

public sealed record CreateEmployeeCommand(Guid organizationId, RoleInOrganization role) : ICommand<Guid>;