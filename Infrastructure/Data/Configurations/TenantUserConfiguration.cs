using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Infrastructure.Data.Configurations
{
    public class TenantUserConfiguration : IEntityTypeConfiguration<TenantUser> // Done
    {
        public void Configure(EntityTypeBuilder<TenantUser> builder)
        {
            builder.HasKey(tu => tu.Id);

            builder.HasOne(tu => tu.Tenant)
                .WithMany(t => t.TenantUsers)
                .HasForeignKey(tu => tu.TenantId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(tu => tu.User)
                .WithMany(u => u.TenantUsers)
                .HasForeignKey(tu => tu.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(tu => new { tu.TenantId, tu.UserId }).IsUnique();
        }
    }
}
