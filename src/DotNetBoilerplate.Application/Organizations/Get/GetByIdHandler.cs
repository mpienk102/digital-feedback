using DotNetBoilerplate.Core.Organizations.Exceptions;
using DotNetBoilerplate.Core.Organizations;
using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.Organizations.Read
{
    internal sealed class GetByIdHandler(
        IOrganizationsRepository organizationsRepository
        ) : IQueryHandler<GetByIdQuery, OrganizationDto>
    {
        public async Task<OrganizationDto> HandleAsync(GetByIdQuery query)
        {
            var organization = await organizationsRepository.GetByIdAsync(query.Id);
            if (organization is null)
            {
                throw new OrganizationIsNullException(query.Id);
            }

            return new OrganizationDto(
                organization.Id,
                organization.Name,
                organization.OwnerId,
                organization.CreatedAt.UtcDateTime
            );
        }
    }
}
