
using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Core.Organizations;
using DotNetBoilerplate.Core.Users;

namespace DotNetBoilerplate.Core.Forms
{
    public class Form
    {
        private Form() { }
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public Guid CreatorId { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public static Form Create(
            string name,
            string description,
            Guid userId,
            DateTimeOffset now
            )
        {
            return new Form
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                CreatorId = userId,
                CreatedAt = now
            };
        }
    }
}
