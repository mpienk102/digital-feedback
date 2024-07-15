namespace DotNetBoilerplate.Core.Projects
{
    public class Project
    {
        private Project() { }
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Status { get; private set; }
        public Guid OrganizationId { get; private set; }
        public Guid CreatorId { get; private set; }
        public DateTimeOffset CreatedAt { get; private set; }

     /*   public enum ProjectStatus
        {
            Public,
            Private,
            Archived
        } */

        public void UpdateName(string name, bool nameIsUnique)
        {
            if (!nameIsUnique)
            {
                throw new Exception("Invalid name");
            }

            Name = name;
        }

        public void UpdateStatus(string status)
        {
            Status = status;
        }

        public static Project Create(
            string name,
            string description,
            string status,
            Guid organizationId,
            Guid creatorId,
            DateTimeOffset createdAt,
            bool nameIsUnique
        )
        {
            if (!nameIsUnique)
                throw new Exception("Invalid name");

            return new Project
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                Status = status,
                OrganizationId = organizationId,
                CreatorId = creatorId,
                CreatedAt = createdAt
            };
        }
    }
}
