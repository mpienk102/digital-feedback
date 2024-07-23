using DotNetBoilerplate.Core.Organizations.Exceptions;
using DotNetBoilerplate.Core.Users;

namespace DotNetBoilerplate.Core.Employees
{
    public class Employee
    {
        private Employee() { }
        public System.Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public System.Guid OrganizationId { get; private set; }
        public RoleInOrganization.Role Role { get; private set; }

        public void UpdateRole(RoleInOrganization.Role role)
        {
            Role = role;
        }

        public bool IsAdmin(System.Guid id)
        {
            return UserId == id && Role == RoleInOrganization.Role.Admin;
        }

        public void SetOrganizationId(System.Guid organizationId)
        {
            OrganizationId = organizationId;
        }

        public void SetRoleAdmin(System.Guid userId, System.Guid organizationId)
        {
            if (UserId == userId && Role == RoleInOrganization.Role.None)
            {
                Role = RoleInOrganization.Role.Admin;
                OrganizationId = organizationId;
            }
            else UserInOrganization(userId, organizationId);
        }

        public static Employee Create(
            System.Guid userId,
            System.Guid organizationId,
            RoleInOrganization.Role role
        )
        {
            return new Employee
            {
                Id = System.Guid.NewGuid(),
                UserId = userId,
                OrganizationId = organizationId,
                Role = role
            };
        }

        public void UserInOrganization(System.Guid userId, System.Guid organizationId)
        {
            if (UserId == userId && Role != RoleInOrganization.Role.None && OrganizationId != organizationId)
                throw new UserInOrganizationException();
        }
    }
}
