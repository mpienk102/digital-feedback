using DotNetBoilerplate.Core.Projects;
using DotNetBoilerplate.Core.Projects.Exceptions;
using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.Projects.Get;

internal sealed class GetProjectByIdHandler(
    IProjectRepository projectRepository
) : IQueryHandler<GetProjectByIdQuery, ProjectDto>
{
    public async Task<ProjectDto> HandleAsync(GetProjectByIdQuery query)
    {
        var project = await projectRepository.GetByIdAsync(query.Id);
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