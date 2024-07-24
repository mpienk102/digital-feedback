using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Core.Organizations;
using DotNetBoilerplate.Core.Projects;
using DotNetBoilerplate.Core.Users;
using DotNetBoilerplate.Core.Forms;
using DotNetBoilerplate.Core.Questions;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetBoilerplate.Infrastructure.DAL.Repositories;

internal static class Extensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, PostgresUserRepository>();

        services.AddScoped<IOrganizationsRepository, PostgresOrganizationsRepository>();

        services.AddScoped<IProjectRepository, PostgresProjectsRepository>();

        services.AddScoped<IEmployeeRepository, PostgresEmployeesRepository>(); 

        services.AddSingleton<IFormRepository, InMemoryFormRepository>(); 

        services.AddSingleton<IQuestionRepository, InMemoryQuestionRepository>(); 

        return services;
    }
}