using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Core.Organizations;
using DotNetBoilerplate.Core.Projects;
using DotNetBoilerplate.Core.Users;
using DotNetBoilerplate.Infrastructure.DAL.Configurations.Write;
using DotNetBoilerplate.Shared.Abstractions.Outbox;
using Microsoft.EntityFrameworkCore;

namespace DotNetBoilerplate.Infrastructure.DAL.Contexts;

internal sealed class DotNetBoilerplateWriteDbContext(DbContextOptions<DotNetBoilerplateWriteDbContext> options)
    : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<OutboxMessage> OutboxMessages { get; set; }

    public DbSet<Organization> Organizations { get; set; }

    public DbSet<Employee> Employees { get; set; } 

    public DbSet<Project> Projects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {         
        modelBuilder
            .HasDefaultSchema("dotNetBoilerplate")
            .ApplyConfiguration(new UserWriteConfiguration())
            .ApplyConfiguration(new OutboxMessageWriteConfiguration())
            .ApplyConfiguration(new OrganizationWriteConfiguration())
            .ApplyConfiguration(new EmployeeWriteConfiguration())
            .ApplyConfiguration(new ProjectWriteConfiguration());
    }
}