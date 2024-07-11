using DotNetBoilerplate.Core.Projects;

namespace DotNetBoilerplate.Infrastructure.DAL.Repositories;

internal sealed class InMemoryProjectsRepository : IProjectRepository
{
    private readonly List<Project> projects = [];


    public Task<Project> GetByIdAsync(Guid id)
    {
        var project = projects.Find(x => x.Id == id);

        return Task.FromResult(project);
    }

    public Task AddAsync(Project project)
    {
        projects.Add(project);

        return Task.CompletedTask;
    }

    public Task UpdateAsync(Project project)
    {
        var index = projects.FindIndex(x => x.Id == project.Id);
        projects[index] = project;

        return Task.CompletedTask;
    }

    public Task DeleteAsync(Project project)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsProjectNameUniqueAsync(string name, Guid? currentprojectId)
    {
        var project = projects.Find(x => x.Name == name);

        return Task.FromResult(project is null || project.Id == currentprojectId);
    }

    public Task<List<Project>> GetAllAsync()
    {
        return Task.FromResult(projects);
    }
}