using DotNetBoilerplate.Shared.Abstractions.Commands;

namespace DotNetBoilerplate.Application.Projects.Read
{
    public sealed class ReadProjectCommand : ICommand<List<ProjectDto>>;
}
