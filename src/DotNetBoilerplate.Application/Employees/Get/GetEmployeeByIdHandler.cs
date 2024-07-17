
//using DotNetBoilerplate.Application.Employees.Exceptions;
using DotNetBoilerplate.Application.Employees.Get;
using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.Employees.Get
{
    internal sealed class GetEmployeeByIdHandler(
        IEmployeeRepository employeeRepository
    ) : IQueryHandler<GetEmployeeByIdQuery, EmployeeDto>
    {
        public async Task<EmployeeDto> HandleAsync(GetEmployeeByIdQuery query)
        {
            var employee = await employeeRepository.GetByIdAsync(query.EmployeeId);
            if (employee is null) throw new Exception("Employee is null exception");

            return new EmployeeDto(
                employee.EmployeeId,
                employee.UserId,
                employee.OrganizationId,
                employee.Role
            );
        }
    }
}
