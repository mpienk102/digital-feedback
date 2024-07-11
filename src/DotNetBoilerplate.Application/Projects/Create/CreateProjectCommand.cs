using DotNetBoilerplate.Shared.Abstractions.Commands;

namespace DotNetBoilerplate.Application.Projects.Create
{
    public sealed record CreateProjectCommand(string Name, string Description, string Status, Guid OrganizationId) : ICommand<Guid>;
}
