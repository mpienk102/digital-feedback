using DotNetBoilerplate.Application.Employees.Exceptions;
using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Core.Organizations;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Contexts;

namespace DotNetBoilerplate.Application.Employees.Delete
{
    internal class DeleteEmployeeHandler(
        IEmployeeRepository employeeRepository,
        IOrganizationsRepository organizationRepository
        ) : ICommandHandler<DeleteEmployeeCommand>
    {
        public async Task HandleAsync(DeleteEmployeeCommand command)
        {
            var employee = await employeeRepository.GetByIdAsync(command.UserId);

            if (employee is null)
                throw new EmployeeNotFoundException(command.UserId);

           await employeeRepository.DeleteAsync(employee);
        }
    }
}