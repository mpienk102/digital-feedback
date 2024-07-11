using DotNetBoilerplate.Core.Projects;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using System.Linq;

namespace DotNetBoilerplate.Application.Projects.Read
{
    internal sealed class ReadProjectHandler(
        IProjectRepository projectRepository    
    ) : ICommandHandler<ReadProjectCommand, List<ProjectDto>>
    {
        public async Task<List<ProjectDto>> HandleAsync(ReadProjectCommand command)
        {
            var projects = await projectRepository.GetAllAsync();
            return projects.Select(p => new ProjectDto(p.Id, p.Name, p.Description, p.Status, p.OrganizationId)).ToList();
        }
    }

    public record ProjectDto(Guid Id, string Name, string Description, string Status, Guid organizationId);
}
