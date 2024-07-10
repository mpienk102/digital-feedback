using DotNetBoilerplate.Application.Organizations.Exceptions;
using DotNetBoilerplate.Core.Organizations;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBoilerplate.Application.Organizations.Update
{
    internal sealed class UpdateOrganizationHandler(
        IOrganizationsRepository organizationsRepository) : ICommandHandler<UpdateOrganizationCommand>
    {
        public async Task HandleAsync( UpdateOrganizationCommand command)
        {
            var organization = await organizationsRepository.GetByIdAsync(command.Id);

            if (organization == null)
            {
                throw new OrganizationNotFoundException(command.Id);
            }

            var isNameUnique = await organizationsRepository.IsOrganizationNameUniqueAsync(command.Name);

            organization.UpdateName(command.Name);

            await organizationsRepository.UpdateAsync(organization);
        }
    }
}
