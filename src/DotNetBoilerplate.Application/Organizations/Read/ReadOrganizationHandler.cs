using DotNetBoilerplate.Core.Organizations;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using System.Linq;

namespace DotNetBoilerplate.Application.Organizations.Read
{
    internal sealed class ReadOrganizationHandler(
        IOrganizationsRepository organizationsRepository
        ) : ICommandHandler<ReadOrganizationCommand, List<OrganizationDto>>
    {
        public async Task<List<OrganizationDto>> HandleAsync(ReadOrganizationCommand command)
        {
            var organizations = await organizationsRepository.GetAllAsync();
            return organizations.Select(o => new OrganizationDto(o.Id, o.Name, o.OwnerId, o.CreatedAt.UtcDateTime)).ToList();
        }
    }

    public record OrganizationDto(Guid Id, string Name, Guid CreatedBy, DateTime CreatedAt);
}
