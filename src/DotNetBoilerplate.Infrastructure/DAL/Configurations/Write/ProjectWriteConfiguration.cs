using DotNetBoilerplate.Core.Organizations;
using DotNetBoilerplate.Core.Projects;
using DotNetBoilerplate.Core.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetBoilerplate.Infrastructure.DAL.Configurations.Write
{
    internal sealed class ProjectWriteConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(p => p.Status)
                .IsRequired();

            builder.Property(p => p.CreatedAt)
                .IsRequired();

            builder
                .HasOne<Organization>()
                .WithMany()
                .HasForeignKey(e => e.OrganizationId)
                .IsRequired();

            builder
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(e => e.CreatorId)
                .IsRequired();
        }
    }
}
