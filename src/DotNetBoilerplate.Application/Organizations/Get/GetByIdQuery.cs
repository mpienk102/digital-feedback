using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.Organizations.Get;

public record GetByIdQuery(Guid Id) : IQuery<OrganizationDto>;