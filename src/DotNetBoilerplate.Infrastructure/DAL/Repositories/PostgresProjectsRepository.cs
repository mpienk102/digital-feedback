using DotNetBoilerplate.Core.Projects;
using DotNetBoilerplate.Infrastructure.DAL.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DotNetBoilerplate.Infrastructure.DAL.Repositories
{
    internal sealed class PostgresProjectsRepository(
        DotNetBoilerplateWriteDbContext dbContext
    ) : IProjectRepository
    {
        public async Task<Project> GetByIdAsync(Guid id)
        {
            return await dbContext.Projects
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task AddAsync(Project project)
        {
            await dbContext.Projects.AddAsync(project);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Project project)
        {
            dbContext.Projects.Update(project);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Project project)
        {
            dbContext.Projects.Remove(project);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> IsProjectNameUniqueAsync(string name, Guid? currentProjectId)
        {
            return !await dbContext.Projects
                .Where(x => x.Name == name && x.Id != currentProjectId)
                .AnyAsync();
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await dbContext.Projects.ToListAsync();
        }
    }
}
