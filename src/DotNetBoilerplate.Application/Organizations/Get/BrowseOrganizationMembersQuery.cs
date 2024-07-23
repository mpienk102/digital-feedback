using DotNetBoilerplate.Application.Employees.Get;
using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.Organizations.Get
{
    public record BrowseOrganizationMembersQuery(Guid organizationId) : IQuery<List<EmployeeListDto>>;
}
