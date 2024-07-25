using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Core.Organizations;
using DotNetBoilerplate.Core.Users;

namespace DotNetBoilerplate.Core.Forms
{
    public class Form
    {
        private Form() { }
        public Guid Id { get; private set; }

        public string Name { get; private set; }
        public string Description { get; private set; }

        public Guid CreatorId { get; private set; }
        public Guid ProjectId { get; private set; }

        public DateTimeOffset CreatedAt { get; private set; }

        public static Form Create(
            string name,
            string description,
            Guid userId,
            Guid projectId,
            DateTimeOffset now
            )
        {
            return new Form
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                CreatorId = userId,
                ProjectId = projectId,
                CreatedAt = now
            };
        }
    }
}
