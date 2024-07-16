using System;
using static DotNetBoilerplate.Core.Employees.Role;

namespace DotNetBoilerplate.Core.Employees
{
    public class Employee
    {
        private Employee(Guid id, Guid organizationId, RoleInOrganization role)
        {
            Id = id;
            UserId = id;
            OrganizationId = organizationId;
            Role = role;
        }

        public Employee()
        {
            Id = Guid.NewGuid();
            UserId = Guid.Empty; 
            OrganizationId = Guid.Empty;
            Role = RoleInOrganization.None;
        }

        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Guid OrganizationId { get; private set; }
        public RoleInOrganization Role { get; private set; }


        public void UpdateRole(RoleInOrganization roleInOrganization)
        {
            Role = roleInOrganization;
        }

        public static Employee Create(Guid userId, Guid organizationId, RoleInOrganization role)
        {
            if (organizationId != Guid.Empty)
                throw new Exception("User already belongs to organization");

            return new Employee(userId, organizationId, role)
            {
                Role = role
            };
        }

        public static Employee New(Guid id, Guid organizationId, RoleInOrganization role)
        {
            return new Employee(id, organizationId, role);
        }
    }
}
