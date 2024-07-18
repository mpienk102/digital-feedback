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
            var Admin = await employeeRepository.GetByUserIdAsync(context.Identity.Id);

            if (!Admin.isAdmin(context.Identity.Id))
                throw new Exception("You are not an Admin!");

            var organization = await organizationRepository.GetByIdAsync(command.OrganizationId);

            var employee = await employeeRepository.GetByUserIdAsync(command.EmployeeId);



            if (employee is null || organization is null) 
                throw new Exception("Given organization or employee does not exist");

            organization.AddMember(employee.UserId);
            employee.SetOrganizationId(command.OrganizationId);
            employee.UpdateRole(command.Role);

            await organizationRepository.UpdateAsync(organization);
            await employeeRepository.UpdateAsync(employee); 

            return organization.Id;
            
        }
    }
}
