using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Infrastructure.Data.Configurations
{
    public class TenantConfiguration : IEntityTypeConfiguration<Tenant> // Done 
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.Slug)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(t => t.Slug).IsUnique();

            builder.HasOne(t => t.Owner)
                .WithMany()
                .HasForeignKey(t => t.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(t => t.Workspaces)
                .WithOne(w => w.Tenant)
                .HasForeignKey(w => w.TenantId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(t => t.Invitations)
               .WithOne(i => i.Tenant)
               .HasForeignKey(i => i.TenantId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(t => t.TenantUsers)
               .WithOne(tu => tu.Tenant)
               .HasForeignKey(tu => tu.TenantId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
