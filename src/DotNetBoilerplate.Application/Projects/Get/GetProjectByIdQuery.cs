using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.Projects.Get;

public record GetProjectByIdQuery(Guid Id) : IQuery<ProjectDto>;