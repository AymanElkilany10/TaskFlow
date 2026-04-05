using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Infrastructure.Data.Configurations
{
    public class InvitationConfiguration : IEntityTypeConfiguration<Invitation> // Done
    {
        public void Configure(EntityTypeBuilder<Invitation> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.InvitedEmail)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(builder => builder.InvitedByUserId)
                .IsRequired()
                .HasMaxLength(450);

            builder.Property(i => i.Token)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasIndex(builder => builder.Token).IsUnique();

            builder.Property(i => i.ExpiresAt)
                .IsRequired();

            builder.Property(i => i.Status)
                .IsRequired()
                .HasDefaultValue(InvitationStatus.Pending);

            builder.HasOne(i => i.Tenant)
                .WithMany()
                .HasForeignKey(i => i.TenantId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(i => i.InvitedBy)
                .WithMany()
                .HasForeignKey(i => i.InvitedByUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
