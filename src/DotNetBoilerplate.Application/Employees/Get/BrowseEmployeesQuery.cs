using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.Employees.Get
{
    public sealed class BrowseEmployeesQuery : IQuery<List<EmployeeDto>>
    {
        public RoleInOrganization.Role? Role { get; set; }
    }
}
