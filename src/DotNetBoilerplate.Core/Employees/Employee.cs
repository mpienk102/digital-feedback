using System;

namespace DotNetBoilerplate.Core.Employees
{
    public class Employee
    {
        private Employee(Guid id, Guid organizationId)
        {
            Id = id;
            UserId = id;
            OrganizationId = organizationId;
            Role = RoleInOrganization.None;
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

        public enum RoleInOrganization
        {
            None, // Defaultowy użytkownik bez uprawnień
            Moderator, // Uprawnienia do może dodawawania pracowników do projektu, może dodawać i edytować projekty
            Admin // Zarządza organizacją, projektami i ich członkami
        }

        public void UpdateRole(RoleInOrganization roleInOrganization)
        {
            Role = roleInOrganization;
        }

        public static Employee Create(Guid userId, Guid organizationId, RoleInOrganization role)
        {
            if (organizationId != Guid.Empty)
                throw new Exception("User already belongs to organization");

            return new Employee(userId, organizationId)
            {
                Role = role
            };
        }

        public static Employee New(Guid id, Guid organizationId)
        {
            return new Employee(id, organizationId);
        }
    }
}
