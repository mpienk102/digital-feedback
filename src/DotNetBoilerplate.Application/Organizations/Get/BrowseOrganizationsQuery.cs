using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.Organizations.Get;

public sealed class BrowseOrganizationsQuery : IQuery<List<OrganizationDto>>;