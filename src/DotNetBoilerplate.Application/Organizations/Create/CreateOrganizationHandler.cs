﻿using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Core.Organizations;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Contexts;
using DotNetBoilerplate.Shared.Abstractions.Time;
using DotNetBoilerplate.Application.Organizations.Exceptions;
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

            await organizationsRepository.AddAsync(organization);

        if (await employeeRepository.ExistsByUserIdAsync(context.Identity.Id) is false)
        { 
            var employee = Employee.Create(
                    context.Identity.Id,
                    organization.Id,
                    RoleInOrganization.Role.Admin
            );

            await employeeRepository.AddAsync(employee);
        }

            return organization.Id;
        }
    }
