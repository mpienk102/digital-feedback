using DotNetBoilerplate.Core.Projects;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Queries;
using System.Linq;

namespace DotNetBoilerplate.Application.Projects.Read
{
    internal sealed class GetProjectHandler(
        IProjectRepository projectRepository    
    ) : IQueryHandler<GetProjectQuery, List<ProjectDto>>
    {
        public async Task<List<ProjectDto>> HandleAsync(GetProjectQuery query)
        {
            var projects = await projectRepository.GetAllAsync();
            return projects.Select(p => new ProjectDto(p.Id, p.Name, p.Description, p.Status, p.OrganizationId)).ToList();
        }
    }

    public record ProjectDto(Guid Id, string Name, string Description, Project.ProjectStatus Status, Guid organizationId);
}
