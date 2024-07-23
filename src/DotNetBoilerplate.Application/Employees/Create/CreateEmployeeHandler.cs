using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Contexts;

namespace DotNetBoilerplate.Application.Employees.Create
{
    internal sealed class CreateEmployeeHandler(
        IEmployeeRepository employeeRepository,
        IContext context
    ) : ICommandHandler<CreateEmployeeCommand, Guid>
    {
        public async Task<Guid> HandleAsync(CreateEmployeeCommand command)
        {
            var employee = Employee.Create(
                command.UserId,
                command.OrganizationId,
                RoleInOrganization.Role.None
            );

            await employeeRepository.AddAsync(employee);

            return employee.Id;
        }
    }
}
