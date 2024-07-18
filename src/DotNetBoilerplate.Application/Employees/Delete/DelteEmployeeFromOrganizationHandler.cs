using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Core.Organizations;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Contexts;

namespace DotNetBoilerplate.Application.Employees.Delete
{
    internal class DeleteEmployeeFromOrganizationHandler(
        IEmployeeRepository employeeRepository,
        IOrganizationsRepository organizationRepository
        ) : ICommandHandler<DeleteEmployeeFromOrganizationCommand>
    {
        public async Task HandleAsync(DeleteEmployeeFromOrganizationCommand command)
        {
            var employee = await employeeRepository.GetByIdAsync(command.UserId);

            if (employee is null)
            {
                throw new Exception("user does not exist");
            }
            // -----------> wywołanie IsAdmin()

            employee.UpdateRole(RoleInOrganization.Role.None);
            employee.SetOrganizationId(Guid.Empty);
            var organizationId = employee.OrganizationId;
            var organization = await organizationRepository.GetByIdAsync(organizationId);
            organization.Members.Remove(command.UserId);
            await employeeRepository.UpdateAsync(employee);

        }
    }
}