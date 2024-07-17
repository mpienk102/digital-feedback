using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Contexts;

namespace DotNetBoilerplate.Application.Employees.Delete
{
    internal class DeleteEmployeeFromOrganizationHandler(
        IEmployeeRepository employeeRepository,
        IContext context
        ) : ICommandHandler<DeleteEmployeeFromOrganizationCommand>
    {
        public async Task HandleAsync(DeleteEmployeeFromOrganizationCommand command)
        {
            var employee = await employeeRepository.GetByIdAsync(command.UserId);

            if (employee is null) {
                throw new Exception("user does not exist");
            }
            var currentUser = context.Identity.Id;

            var admin = await employeeRepository.GetByIdAsync(currentUser);

            if (admin == null || admin.Role != RoleInOrganization.Role.Admin)
            {
                throw new UnauthorizedAccessException("Only admins can update roles.");
            }

            employee.UpdateRole(RoleInOrganization.Role.None);
            employee.SetOrganizationIdToNone();
            
            await employeeRepository.UpdateAsync(employee);

        }
    }
}
