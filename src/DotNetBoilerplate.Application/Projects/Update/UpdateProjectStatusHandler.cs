using DotNetBoilerplate.Application.Projects.Exceptions;
using DotNetBoilerplate.Core.Projects;
using DotNetBoilerplate.Shared.Abstractions.Commands;

namespace DotNetBoilerplate.Application.Projects.Update
{
    internal sealed class UpdateProjectStatusHandler(
        IProjectRepository projectRepository) : ICommandHandler<UpdateProjectStatusCommand>
    {
        public async Task HandleAsync(UpdateProjectStatusCommand command)
        {
            var project = await projectRepository.GetByIdAsync(command.Id);

            if (project is null) throw new ProjectNotFoundException(command.Id);

            project.UpdateStatus(command.Status);

            await projectRepository.UpdateAsync(project);
        }
    }
}
