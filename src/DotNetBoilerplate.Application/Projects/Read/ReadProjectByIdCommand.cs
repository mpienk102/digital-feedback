using DotNetBoilerplate.Shared.Abstractions.Commands;

namespace DotNetBoilerplate.Application.Projects.Read
{
    public record ReadProjectByIdCommand(Guid Id) : ICommand<ProjectDto>;
}
