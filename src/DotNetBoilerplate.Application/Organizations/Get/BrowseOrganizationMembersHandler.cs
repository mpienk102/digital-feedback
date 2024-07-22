
using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Core.Organizations;
using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.Organizations.Get
{
    internal sealed class BrowseOrganizationMembersHandler(
        IEmployeeRepository employeeRepository
    ) : IQueryHandler<BrowseOrganizationMembersQuery, List<EmployeeListDto>>
    {   
        public async Task<List<EmployeeListDto>> HandleAsync(BrowseOrganizationMembersQuery query)
        {
            var employees = await employeeRepository.BrowseByOrganizationId(query.organizationId);
            return employees.Select(e => new EmployeeListDto(e.EmployeeId, e.Role)).ToList();
        }
    }

    public record EmployeeListDto(Guid Id, RoleInOrganization.Role Role);
}
