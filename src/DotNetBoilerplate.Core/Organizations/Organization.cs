using DotNetBoilerplate.Core.Organizations.Exceptions;
using DotNetBoilerplate.Core.Users;

namespace DotNetBoilerplate.Core.Organizations;

public class Organization
{
    private Organization()
    {
    }

    public System.Guid Id { get; private set; }
    public string Name { get; private set; }
    public Guid OwnerId { get; private set; }

    public DateTimeOffset CreatedAt { get; private set; }

    public void UpdateName(string name, bool nameIsUnique)
    {
        if (!nameIsUnique)
            throw new OrganizationNameIsNotUniqueException();

        Name = name;
    }


    public static Organization Create(
        string name,
        System.Guid ownerId,
        DateTimeOffset now,
        bool nameIsUnique
    )
    {
        if (!nameIsUnique)
            throw new OrganizationNameIsNotUniqueException();

        return new Organization
        {
            Id = System.Guid.NewGuid(),
            Name = name,
            OwnerId = ownerId,
            CreatedAt = now
        };
    }
}