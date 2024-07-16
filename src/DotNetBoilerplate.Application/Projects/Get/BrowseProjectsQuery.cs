using DotNetBoilerplate.Core.Projects;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.Projects.Read
{
    public sealed class GetProjectQuery : IQuery<List<ProjectDto>>
    {
        public Project.ProjectStatus? Status { get; set; }
    }
}
