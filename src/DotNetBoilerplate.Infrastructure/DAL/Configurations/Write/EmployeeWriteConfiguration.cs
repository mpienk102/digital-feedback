using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Core.Organizations;
using DotNetBoilerplate.Core.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetBoilerplate.Infrastructure.DAL.Configurations.Write;

internal sealed class EmployeeWriteConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(e => e.Id);


        builder.Property(e => e.OrganizationId)
            .IsRequired();

        builder.Property(e => e.Role)
            .IsRequired();

        // Definicja relacji z encją User
        builder
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(e => e.UserId)
            .IsRequired();

        // Definicja relacji z encją Organization
        builder
            .HasOne<Organization>()
            .WithMany()
            .HasForeignKey(e => e.OrganizationId)
            .IsRequired();
    }
}
