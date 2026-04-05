using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Infrastructure.Data.Configurations
{
    public class UserProjectConfiguration : IEntityTypeConfiguration<UserProject> // In Progress
    {
        public void Configure(EntityTypeBuilder<UserProject> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(up => new { up.UserId, up.ProjectId }).IsUnique();

            builder.HasOne(up => up.User)
                .WithMany(u => u.UserProjects)
                .HasForeignKey(up => up.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(up => up.Project)
                .WithMany(p => p.UserProjects)
                .HasForeignKey(up => up.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(up => up.Role)
                .HasConversion<string>()
                .IsRequired();
        }
    }
}
