using TaskFlow.Domain.Common;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Domain.Entities
{
    public class UserProject : BaseEntity
    {
        public string UserId { get; set; } = string.Empty;
        public AppUser User { get; set; } = null!;
        public Guid ProjectId { get; set; }
        public Project Project { get; set; } = null!;
        public ProjectRole Role { get; set; }
    }
}