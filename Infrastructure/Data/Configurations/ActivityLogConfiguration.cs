using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Infrastructure.Data.Configurations
{
    public class ActivityLogConfiguration : IEntityTypeConfiguration<ActivityLog>
    {
        public void Configure(EntityTypeBuilder<ActivityLog> builder)
        {
            builder.HasKey(al => al.Id);

            builder.Property(al => al.TenantId)
                .IsRequired();

            builder.Property(al => al.ActionType)
                .IsRequired();

            builder.Property(al => al.EntityType)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(al => al.EntityId)
                .IsRequired();

            builder.HasIndex(al => new { al.TenantId, al.UserId });

            builder.HasOne(builder => builder.Tenant)
                .WithMany()
                .HasForeignKey(builder => builder.TenantId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(builder => builder.User)
                .WithMany()
                .HasForeignKey(builder => builder.UserId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
