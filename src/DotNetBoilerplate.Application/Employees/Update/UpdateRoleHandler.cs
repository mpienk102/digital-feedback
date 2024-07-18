using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Contexts;

namespace DotNetBoilerplate.Application.Employees.Update
{
    internal sealed class UpdateRoleHandler(
        IEmployeeRepository employeeRepository,
        IContext context
    ) : ICommandHandler<UpdateRoleCommand>
    {
        public async Task HandleAsync(UpdateRoleCommand command)
        {
            //var currentUser = context.Identity.Id;

            //var admin = await employeeRepository.GetByIdAsync(currentUser);
            //if (admin == null || admin.Role != RoleInOrganization.Role.Admin)
            //{
            //    throw new UnauthorizedAccessException("Only admins can update roles.");
            //}

            var employee = await employeeRepository.GetByIdAsync(command.UserId);
            if (employee == null || employee.OrganizationId != command.OrganizationId)
            {
                throw new InvalidOperationException("Employee not found or does not belong to the organization.");
            }

            if (command.NewRole != RoleInOrganization.Role.None && command.NewRole != RoleInOrganization.Role.Moderator)
            {
                throw new InvalidOperationException("Role can only be updated to None or Moderator.");
            }

            employee.UpdateRole(command.NewRole);
            await employeeRepository.UpdateAsync(employee);
        }
    }
}