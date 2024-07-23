using DotNetBoilerplate.Application.Organizations.Exceptions;
using DotNetBoilerplate.Core.Organizations;
using DotNetBoilerplate.Shared.Abstractions.Commands;

namespace DotNetBoilerplate.Application.Organizations.Update;

internal sealed class UpdateOrganizationHandler(
    IOrganizationsRepository organizationsRepository) : ICommandHandler<UpdateOrganizationCommand>
{
    public async Task HandleAsync(UpdateOrganizationCommand command)
    {
        var organization = await organizationsRepository.GetByIdAsync(command.Id);

        if (organization is null) throw new OrganizationNotFoundException(command.Id);

        var isNameUnique = await organizationsRepository.IsOrganizationNameUniqueAsync(command.Name, organization.Id);

        organization.UpdateName(command.Name, isNameUnique);

        await organizationsRepository.UpdateAsync(organization);
    }
}