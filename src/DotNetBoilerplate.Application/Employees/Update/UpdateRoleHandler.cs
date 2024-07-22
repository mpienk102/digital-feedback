using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Contexts;
using DotNetBoilerplate.Application.Employees.Exceptions;
namespace DotNetBoilerplate.Application.Employees.Update
{
    internal sealed class UpdateRoleHandler(
        IEmployeeRepository employeeRepository,
        IContext context
    ) : ICommandHandler<UpdateRoleCommand>
    {
        public async Task HandleAsync(UpdateRoleCommand command)
        {

            var employee = await employeeRepository.GetByIdAsync(command.UserId);
            if (employee is null)
                throw new EmployeeNotFoundException(command.UserId);

            if(employee.OrganizationId != command.OrganizationId)
                throw new EmployeeDoesNotBelongToOrganizationException(command.OrganizationId, command.UserId);

            bool isPermitted = command.NewRole != RoleInOrganization.Role.None && command.NewRole != RoleInOrganization.Role.Moderator;

            if (isPermitted)
                throw new MissingPermissionException();

            employee.UpdateRole(command.NewRole);
            await employeeRepository.UpdateAsync(employee);
        }
    }
}