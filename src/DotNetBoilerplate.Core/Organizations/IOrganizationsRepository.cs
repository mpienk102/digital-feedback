namespace DotNetBoilerplate.Core.Organizations;

public interface IOrganizationsRepository
{
    Task<Organization?> GetByIdAsync(Guid id);

    Task<List<Organization>> GetAllAsync();

    Task AddAsync(Organization organization);
    Task UpdateAsync(Organization organization);
    Task DeleteAsync(Organization organization);

    Task<bool> IsOrganizationNameUniqueAsync(string name, Guid? currentOrganizationId);
}