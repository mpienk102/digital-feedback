using DotNetBoilerplate.Shared.Abstractions.Commands;
namespace DotNetBoilerplate.Application.Employees.Delete
{
    public sealed record DeleteEmployeeFromOrganizationCommand(Guid UserId) : ICommand<Guid>;
}
