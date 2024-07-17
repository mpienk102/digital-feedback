using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Core.Organizations;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Contexts;
using DotNetBoilerplate.Shared.Abstractions.Time;

namespace DotNetBoilerplate.Application.Organizations.Create
{
    internal sealed class CreateOrganizationHandler(
        IOrganizationsRepository organizationsRepository,
        IEmployeeRepository employeesRepository,
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

            var employee = await employeesRepository.GetByUserIdAsync(context.Identity.Id);

            if (employee == null)
            {
                employee = Employee.Create(
                    context.Identity.Id,
                    organization.Id,
                    RoleInOrganization.Role.None
                );
                await employeesRepository.AddAsync(employee);
            }

            employee.SetRoleAdmin(context.Identity.Id, organization.Id);

            await employeesRepository.UpdateAsync(employee);

            Console.WriteLine(employee.isAdmin(context.Identity.Id));

            organization.AddMember(context.Identity.Id);

            await organizationsRepository.AddAsync(organization);

            return organization.Id;
        }
    }
}
