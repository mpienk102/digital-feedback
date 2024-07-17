using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Contexts;

namespace DotNetBoilerplate.Application.Employees.Delete
{
    internal class DeleteEmployeeFromOrganizationHandler(
        IEmployeeRepository employeeRepository
        ) : ICommandHandler<DeleteEmployeeFromOrganizationCommand>
    {
        public async Task HandleAsync(DeleteEmployeeFromOrganizationCommand command)
        {
            var employee = await employeeRepository.GetByIdAsync(command.UserId);

            if (employee is null) {
                throw new Exception("user does not exist");
            }
            // -----------> wywołanie IsAdmin()

            employee.UpdateRole(RoleInOrganization.Role.None);
            employee.SetOrganizationIdToNone();
            
            await employeeRepository.UpdateAsync(employee);

        }
    }
}
