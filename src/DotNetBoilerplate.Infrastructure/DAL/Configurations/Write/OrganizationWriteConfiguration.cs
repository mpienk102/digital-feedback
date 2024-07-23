using DotNetBoilerplate.Core.Organizations;
using DotNetBoilerplate.Core.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetBoilerplate.Infrastructure.DAL.Configurations.Write;

internal sealed class OrganizationWriteConfiguration : IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(o => o.CreatedAt)
            .IsRequired();

        builder
            .HasOne<User>()
            .WithOne()
            .HasForeignKey<Organization>(x => x.OwnerId)
            .IsRequired();
    }
}