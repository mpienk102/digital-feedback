//using DotNetBoilerplate.Core.Projects.Exceptions;

namespace DotNetBoilerplate.Core.Projects
{
    public class Project
    {
        private Project() { } 
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Status {  get; private set; }
        public Guid OrganizationId { get; private set; }

        public void UpdateName(string name, bool nameIsUnique)
        {
            if (!nameIsUnique)
            {
                throw new Exception("Invalid name");
            }

            Name = name;
        }

        public static Project Create(
            string name,
            string description,
            string status,
            Guid organizationId,
            bool nameIsUnique
        )
        {
            if (!nameIsUnique) { } //

            return new Project
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                Status = status,
                OrganizationId = organizationId
            };
        }
    }
}
