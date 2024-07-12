using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.Projects.Read
{
    public record GetProjectByIdQuery(Guid Id) : IQuery<ProjectDto>;
}
