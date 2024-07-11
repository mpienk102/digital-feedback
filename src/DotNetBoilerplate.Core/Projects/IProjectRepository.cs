namespace DotNetBoilerplate.Core.Projects;

public interface IProjectRepository
{
    Task<Project?> GetByIdAsync(Guid id);
    Task<List<Project>> GetAllAsync();
    Task AddAsync(Project project);
    Task UpdateAsync(Project project);
    Task DeleteAsync(Project project);
    Task<bool> IsProjectNameUniqueAsync(string name, Guid? currentProjectId);
}
