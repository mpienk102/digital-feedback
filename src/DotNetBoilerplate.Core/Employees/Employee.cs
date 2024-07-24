using DotNetBoilerplate.Core.Organizations.Exceptions;
using DotNetBoilerplate.Core.Users;

namespace DotNetBoilerplate.Core.Employees
{
    public class Employee
    {
        private Employee() { }
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Guid OrganizationId { get; private set; }
        public RoleInOrganization.Role Role { get; private set; }

        public void UpdateRole(RoleInOrganization.Role role)
        {
            Role = role;
        }

        public bool IsAdmin(Guid id)
        {
            return UserId == id && Role == RoleInOrganization.Role.Admin;
        }

        public void SetOrganizationId(Guid organizationId)
        {
            OrganizationId = organizationId;
        }

        public void SetRoleAdmin(Guid userId, Guid organizationId)
        {
            if (UserId == userId && Role == RoleInOrganization.Role.None)
            {
                Role = RoleInOrganization.Role.Admin;
                OrganizationId = organizationId;
            }
            else UserInOrganization(userId, organizationId);
        }

        public static Employee Create(
            Guid userId,
            Guid organizationId,
            RoleInOrganization.Role role
        )
        {
            return new Employee
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                OrganizationId = organizationId,
                Role = role
            };
        }

        public void UserInOrganization(Guid userId, Guid organizationId)
        {
            if (UserId == userId && Role != RoleInOrganization.Role.None && OrganizationId != organizationId)
                throw new UserInOrganizationException();
        }
    }
}
