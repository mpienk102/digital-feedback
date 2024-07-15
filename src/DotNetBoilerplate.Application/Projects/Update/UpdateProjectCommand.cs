using DotNetBoilerplate.Shared.Abstractions.Commands;

namespace DotNetBoilerplate.Application.Projects.Update
{
    public sealed record UpdateProjectCommand(Guid Id, string Name, string Description) : ICommand;

}
