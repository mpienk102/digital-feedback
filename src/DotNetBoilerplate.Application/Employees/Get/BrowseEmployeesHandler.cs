using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.Employees.Get
{
    internal sealed class BrowseEmployeesHandler(
        IEmployeeRepository employeeRepository    
    ) : IQueryHandler<BrowseEmployeesQuery, List<EmployeeDto>>
    {
        public async Task<List<EmployeeDto>> HandleAsync(BrowseEmployeesQuery query)
        {
            var employees = await employeeRepository.GetAllAsync();

            if (query.Role is not null)
                employees = employees.Where(e => e.Role == query.Role).ToList();

            return employees.Select(e => new EmployeeDto(e.EmployeeId, e.UserId, e.OrganizationId, e.Role)).ToList();
        }
    }

    public record EmployeeDto(Guid EmployeeId, Guid UserId, Guid OrganizationId, RoleInOrganization.Role Role);
}
