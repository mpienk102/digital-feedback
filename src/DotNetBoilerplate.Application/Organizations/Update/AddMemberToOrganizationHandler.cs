using DotNetBoilerplate.Application.Organizations.Exceptions;
using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Core.Organizations;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBoilerplate.Application.Organizations.Update
{
    internal sealed class AddMemberToOrganizationHandler(
        IOrganizationsRepository organizationRepository,
        IEmployeeRepository employeeRepository,
        IContext context
        ) : ICommandHandler<AddMemberToOrganizationCommand, Guid>

    {
        public async Task<Guid> HandleAsync(AddMemberToOrganizationCommand command )
        {
            var admin = await employeeRepository.GetByIdAsync(context.Identity.Id);

            if (admin.IsAdmin(context.Identity.Id))
                throw new MissingAdminRoleException(command.OrganizationId);

            var organization = await organizationRepository.GetByIdAsync(command.OrganizationId);

            var employee = await employeeRepository.GetByIdAsync(command.EmployeeId);



            // if (employee is null || organization is null) 
            //    throw new Exception("Given organization or employee does not exist");
            if (organization is null)
                throw new OrganizationNotFoundException(command.OrganizationId);
            if (employee is null)
                throw new EmployeeNotFoundException(command.EmployeeId);

            organization.AddMember(employee.UserId);

            employee.UpdateRole(command.Role);

            await organizationRepository.UpdateAsync(organization);
            await employeeRepository.UpdateAsync(employee); 

            return organization.Id;
            
        }
    }
}
