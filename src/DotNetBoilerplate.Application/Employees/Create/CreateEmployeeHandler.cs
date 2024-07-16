using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Core.Organizations;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Contexts;
using DotNetBoilerplate.Shared.Abstractions.Time;

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
                context.Identity.Id,
                context.Identity.Id,
                command.role
                );
            await employeeRepository.AddAsync( employee );
            return employee.Id;
        }
    }
}
