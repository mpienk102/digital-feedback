using System.Text.Json.Serialization;
using DotNetBoilerplate.Api.Employees;
using DotNetBoilerplate.Api.Forms;
using DotNetBoilerplate.Api.Organizations;
using DotNetBoilerplate.Api.Projects;
using DotNetBoilerplate.Api.Users;
using DotNetBoilerplate.Application;
using DotNetBoilerplate.Core;
using DotNetBoilerplate.Infrastructure;
using DotNetBoilerplate.Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddShared()
    .AddApplication()
    .AddCore()
    .AddInfrastructure(builder.Configuration)
    .AddControllers()
    .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });

var app = builder.Build();

app.MapUsersEndpoints();

app.MapOrganizationsEndpoints();

app.MapProjectsEndpoints();

app.MapEmployeesEndpoints();

app.UseInfrastructure();

app.MapFormsEndpoints();

await app.RunAsync();