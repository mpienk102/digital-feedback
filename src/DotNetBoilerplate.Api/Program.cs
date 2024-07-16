using System.Text.Json.Serialization;
using DotNetBoilerplate.Api.Employees;
using DotNetBoilerplate.Api.Organizations;
using DotNetBoilerplate.Api.Projects;
using DotNetBoilerplate.Api.Users;
using DotNetBoilerplate.Application;
using DotNetBoilerplate.Application.Projects.Read;
using DotNetBoilerplate.Core;
using DotNetBoilerplate.Core.Projects;
using DotNetBoilerplate.Infrastructure;
using DotNetBoilerplate.Shared;
using DotNetBoilerplate.Shared.Abstractions.Queries;
/*using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using static DotNetBoilerplate.Core.Projects.Project;*/

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddShared()
    .AddApplication()
    .AddCore()
    .AddInfrastructure(builder.Configuration)
    .AddControllers()
    .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });

//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

//    // Obs³uga enumów jako stringów w Swaggerze
//    c.MapType<ProjectStatus>(() => new OpenApiSchema
//    {
//        Type = "string",
//        Enum = Enum.GetNames(typeof(ProjectStatus)).Select(name => (IOpenApiAny)new OpenApiString(name)).ToList()
//    });
//});

var app = builder.Build();

app.MapUsersEndpoints();

app.MapOrganizationsEndpoints();

app.MapProjectsEndpoints();

app.MapEmployeesEndpoints();

app.UseInfrastructure();

await app.RunAsync();