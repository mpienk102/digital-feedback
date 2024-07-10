using DotNetBoilerplate.Core.Organizations;

namespace DotNetBoilerplate.Infrastructure.DAL.Repositories;

internal sealed class InMemoryOrganizationsRepository : IOrganizationsRepository
{
    private readonly List<Organization> organizations = [];


    public Task<Organization> GetByIdAsync(Guid id)
    {
        var organization = organizations.Find(x => x.Id == id);

        return Task.FromResult(organization);
    }

    public Task AddAsync(Organization organization)
    {
        organizations.Add(organization);

        return Task.CompletedTask;
    }

    public Task UpdateAsync(Organization organization)
    {
        var index = organizations.FindIndex(x => x.Id == organization.Id);
        organizations[index] = organization;

        return Task.CompletedTask;
    }

    public Task DeleteAsync(Organization organization)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsOrganizationNameUniqueAsync(string name, Guid? currentOrganizationId)
    {
        var organization = organizations.Find(x => x.Name == name);

        return Task.FromResult(organization is null || organization.Id == currentOrganizationId);
    }
}