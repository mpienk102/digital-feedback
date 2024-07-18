using DotNetBoilerplate.Core.Organizations;
using DotNetBoilerplate.Infrastructure.DAL.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DotNetBoilerplate.Infrastructure.DAL.Repositories;

internal sealed class PostgresOrganizationsRepository(
    DotNetBoilerplateWriteDbContext dbContext
) : IOrganizationsRepository
{
    public async Task<Organization> GetByIdAsync(Guid id)
    {
        return await dbContext.Organizations
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<List<Organization>> GetAllAsync()
    {
        return await dbContext.Organizations
            .ToListAsync();
    }

    public async Task AddAsync(Organization organization)
    {
        await dbContext.Organizations.AddAsync(organization);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Organization organization)
    {
        dbContext.Organizations.Update(organization);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Organization organization)
    {
        dbContext.Organizations.Remove(organization);
        await dbContext.SaveChangesAsync();
    }

    public async Task<bool> IsOrganizationNameUniqueAsync(string name, Guid? currentOrganizationId)
    {
        return !await dbContext.Organizations
            .Where(x => x.Name == name && x.Id != currentOrganizationId)
            .AnyAsync();
    }
}