namespace DotNetBoilerplate.Core.Projects;

public class Project
{
    public enum ProjectStatus
    {
        Public,
        Private,
        Archived
    }

    private Project()
    {
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public ProjectStatus Status { get; private set; }
    public Guid OrganizationId { get; private set; }
    public Guid CreatorId { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }

    public void UpdateName(string name, bool nameIsUnique)
    {
        //! Rzucać custom exception
        if (!nameIsUnique) throw new Exception("Invalid name");

        Name = name;
    }

    public void UpdateStatus(ProjectStatus status)
    {
        Status = status;
    }

    public static Project Create(
        string name,
        string description,
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
            Status = ProjectStatus.Private,
            OrganizationId = organizationId,
            CreatorId = creatorId,
            CreatedAt = createdAt
        };
    }
}