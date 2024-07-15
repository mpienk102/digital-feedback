using DotNetBoilerplate.Core.Projects;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Contexts;
using DotNetBoilerplate.Shared.Abstractions.Time;

namespace DotNetBoilerplate.Application.Projects.Create;

internal sealed class CreateProjectHandler(
    IProjectRepository projectRepository,
    IContext context,
    IClock clock
) : ICommandHandler<CreateProjectCommand, Guid>
{
    public async Task<Guid> HandleAsync(CreateProjectCommand command)
    {
        var isNameUnique = await projectRepository.IsProjectNameUniqueAsync(command.Name, null);

        var project = Project.Create(
            command.Name,
            command.Description,
            context.Identity.Id,
            context.Identity.Id,
            clock.Now(),
            isNameUnique
        );

        await projectRepository.AddAsync(project);

        return project.Id;
    }
}