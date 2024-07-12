using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.Projects.Read
{
    public sealed class GetProjectQuery : IQuery<List<ProjectDto>>;
}
