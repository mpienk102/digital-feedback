using DotNetBoilerplate.Core.Organizations.Exceptions;
using DotNetBoilerplate.Core.Projects;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.Projects.Read
{
    internal sealed class GetProjectByIdHandler (
        IProjectRepository projectRepository    
    ) : IQueryHandler<GetProjectByIdQuery, ProjectDto>
    {
        public async Task<ProjectDto> HandleAsync(GetProjectByIdQuery query )
        {
            var project = await projectRepository.GetByIdAsync(query.Id );
            if (project is null) throw new ProjectIsNullException(query.Id);

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
