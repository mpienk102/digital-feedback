using DotNetBoilerplate.Application.Projects.Delete;
using DotNetBoilerplate.Core.Projects;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Contexts;

namespace DotNetBoilerplate.Application.Projects.Delete
{
    internal sealed class DeleteProjectHandler(
        IProjectRepository projectRepository,
        IContext context
    ) : ICommandHandler<DeleteProjectCommand>
    {
        public async Task HandleAsync(DeleteProjectCommand command)
        {
            var project = await projectRepository.GetByIdAsync(command.ProjectId);

            if (project == null)
            {
                throw new Exception("Project not found.");
            }

            /*   if (project.CreatorId != context.Identity.Id)
               {
                   throw new Exception("You do not have permission to delete this project.");
               } */

            await projectRepository.DeleteAsync(project);
        }
    }
}