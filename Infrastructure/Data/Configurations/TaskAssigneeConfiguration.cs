using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Infrastructure.Data.Configurations
{
    public class TaskAssigneeConfiguration : IEntityTypeConfiguration<TaskAssignee> // Done
    {
        public void Configure(EntityTypeBuilder<TaskAssignee> builder)
        {
            builder.HasKey( ta => ta.Id );

            builder.HasIndex(builder => new { builder.TaskId, builder.UserId }).IsUnique();

            builder.HasOne(ta => ta.Task)
                .WithMany()
                .HasForeignKey(ta => ta.TaskId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ta => ta.User)
                .WithMany(u => u.TaskAssignees)
                .HasForeignKey(ta => ta.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
