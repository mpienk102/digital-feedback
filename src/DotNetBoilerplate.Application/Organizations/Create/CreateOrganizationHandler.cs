using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Core.Organizations;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Contexts;
using DotNetBoilerplate.Shared.Abstractions.Time;

namespace DotNetBoilerplate.Application.Organizations.Create;

internal sealed class CreateOrganizationHandler(
    IOrganizationsRepository organizationsRepository,
    IEmployeeRepository employeeRepository,
    IContext context,
    IClock clock
) : ICommandHandler<CreateOrganizationCommand, Guid>
{
    public async Task<Guid> HandleAsync(CreateOrganizationCommand command)
    {
        var isNameUnique = await organizationsRepository.IsOrganizationNameUniqueAsync(command.Name, null);

        var organization = Organization.Create(
            command.Name,
            context.Identity.Id,
            clock.Now(),
            isNameUnique
        );

        organization.Members.Add(context.Identity.Id);

        await organizationsRepository.AddAsync(organization);

        var employee = await employeeRepository.GetByUserIdAsync(context.Identity.Id);

        employee.SetRoleAdmin(context.Identity.Id, organization.Id);

        await employeeRepository.UpdateAsync(employee);

        return organization.Id;
    }
}