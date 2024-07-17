namespace DotNetBoilerplate.Core.Employees
{
    public class Employee
    {
        private Employee() { }
        public Guid EmployeeId { get; private set; }
        public Guid UserId { get; private set; }
        public Guid OrganizationId { get; private set; }
        public RoleInOrganization.Role Role { get; private set; }

        public void UpdateRole(RoleInOrganization.Role role)
        {
            Role = role;
        }

        public bool isAdmin(Guid Id)
        {
            return this.UserId == Id && this.Role == RoleInOrganization.Role.Admin;
        }

        public void SetRoleAdmin(Guid userId, Guid organizationId)
        {
            if (this.UserId == userId && this.Role == RoleInOrganization.Role.None)
            {
                this.Role = RoleInOrganization.Role.Admin;
                this.OrganizationId = organizationId;
            }
            else if (this.UserId == userId && this.Role != RoleInOrganization.Role.None && this.OrganizationId != organizationId)
            {
                throw new Exception("User already has a role in another organization");
            }
        }


        public static Employee Create (
            Guid userId,
            Guid organizationId,
            RoleInOrganization.Role role
        )
        {
            return new Employee
            {
                EmployeeId = Guid.NewGuid(),
                UserId = userId,
                OrganizationId = organizationId,
                Role = role
            };
        }
    }
}
