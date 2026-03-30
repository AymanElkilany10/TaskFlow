using TaskFlow.Domain.Common;

namespace TaskFlow.Domain.Entities
{
    public class Project : SoftDeletableEntity
    {
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; } = null!;
        public Guid WorkspaceId { get; set; }
        public Workspace Workspace { get; set; } = null!;
        public string ProjectManagerId { get; set; } = string.Empty;
        public AppUser ProjectManager { get; set; } = null!;
        public string Name { get; set; } = string.Empty;
        public ICollection<Board> Boards { get; set; } = new List<Board>();
        public ICollection<UserProject> UserProjects { get; set; } = new List<UserProject>();
    }
}