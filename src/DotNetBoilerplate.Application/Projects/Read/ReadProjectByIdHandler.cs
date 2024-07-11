using DotNetBoilerplate.Core.Organizations.Exceptions;
using DotNetBoilerplate.Core.Projects;
using DotNetBoilerplate.Shared.Abstractions.Commands;

namespace DotNetBoilerplate.Application.Projects.Read
{
    internal sealed class ReadProjectByIdHandler (
        IProjectRepository projectRepository    
    ) : ICommandHandler<ReadProjectByIdCommand, ProjectDto>
    {
        public async Task<ProjectDto> HandleAsync(ReadProjectByIdCommand command )
        {
            var project = await projectRepository.GetByIdAsync( command.Id );
            if (project is null) throw new ProjectIsNullException(command.Id);

            return new ProjectDto(
                project.Id,
                project.Name,
                project.Description,
                project.Status,
                project.OrganizationId
            );
        }
    }
}
