using DotNetBoilerplate.Shared.Abstractions.Commands;

namespace DotNetBoilerplate.Application.Projects.Delete
{
    public sealed record DeleteProjectCommand(Guid ProjectId) : ICommand<Guid>;
}