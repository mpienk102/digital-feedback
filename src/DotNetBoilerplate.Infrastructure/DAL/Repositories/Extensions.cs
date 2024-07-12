using DotNetBoilerplate.Application.Projects.Read;
using DotNetBoilerplate.Core.Organizations;
using DotNetBoilerplate.Core.Projects;
using DotNetBoilerplate.Core.Users;
using DotNetBoilerplate.Shared.Abstractions.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetBoilerplate.Infrastructure.DAL.Repositories;

internal static class Extensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, PostgresUserRepository>();

        services.AddSingleton<IOrganizationsRepository, InMemoryOrganizationsRepository>();

        services.AddSingleton<IProjectRepository, InMemoryProjectsRepository>();

        return services;
    }
}