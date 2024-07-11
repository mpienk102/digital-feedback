using DotNetBoilerplate.Application.Projects.Exceptions;
using DotNetBoilerplate.Core.Projects;
using DotNetBoilerplate.Shared.Abstractions.Commands;

namespace DotNetBoilerplate.Application.Projects.Update;

internal sealed class UpdateProjectHandler(
    IProjectRepository projectRepository) : ICommandHandler<UpdateProjectCommand>
{
    public async Task HandleAsync(UpdateProjectCommand command)
    {
        var project = await projectRepository.GetByIdAsync(command.Id);

        if (project is null) throw new ProjectNotFoundException(command.Id);

        var isNameUnique = await projectRepository.IsProjectNameUniqueAsync(command.Name, project.Id);

        project.UpdateName(command.Name, isNameUnique);

        await projectRepository.UpdateAsync(project);
    }
}