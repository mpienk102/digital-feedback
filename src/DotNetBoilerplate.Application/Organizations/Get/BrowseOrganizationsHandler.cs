using DotNetBoilerplate.Core.Organizations;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Queries;
using System.Linq;

namespace DotNetBoilerplate.Application.Organizations.Read
{
    internal sealed class BrowseOrganizationsHandler(
        IOrganizationsRepository organizationsRepository
        ) : IQueryHandler<BrowseOrganizationsQuery, List<OrganizationDto>>
    {
        public async Task<List<OrganizationDto>> HandleAsync(BrowseOrganizationsQuery query)
        {
            var organizations = await organizationsRepository.GetAllAsync();
            return organizations.Select(o => new OrganizationDto(o.Id, o.Name, o.OwnerId, o.CreatedAt.UtcDateTime)).ToList();
        }
    }

    public record OrganizationDto(Guid Id, string Name, Guid CreatedBy, DateTime CreatedAt);
}
