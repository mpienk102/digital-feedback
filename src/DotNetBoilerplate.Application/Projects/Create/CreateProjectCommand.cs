using DotNetBoilerplate.Core.Projects;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using static DotNetBoilerplate.Core.Projects.Project;

namespace DotNetBoilerplate.Application.Projects.Create
{
    public sealed record CreateProjectCommand(string Name, string Description, string Status, Guid OrganizationId, Guid CreatorId, DateTimeOffset CreatedAt) : ICommand<Guid>;
}
