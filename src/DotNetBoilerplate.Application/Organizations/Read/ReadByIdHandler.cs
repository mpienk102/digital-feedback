using DotNetBoilerplate.Core.Organizations.Exceptions;
using DotNetBoilerplate.Core.Organizations;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace DotNetBoilerplate.Application.Organizations.Read
{
    internal sealed class ReadByIdHandler(
        IOrganizationsRepository organizationsRepository
        ) : ICommandHandler<ReadByIdCommand, OrganizationDto>
    {
        public async Task<OrganizationDto> HandleAsync(ReadByIdCommand command)
        {
            var organization = await organizationsRepository.GetByIdAsync(command.Id);
            if (organization is null)
            {
                throw new OrganizationIsNullException(command.Id);
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
