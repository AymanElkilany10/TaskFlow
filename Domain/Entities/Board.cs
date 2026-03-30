using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TaskFlow.Domain.Common;

namespace TaskFlow.Domain.Entities
{
    public class Board : SoftDeletableEntity
    {
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; } = null!;
        public Guid ProjectId { get; set; }
        public Project Project { get; set; } = null!;
        public string Name { get; set; } = string.Empty;
        public ICollection<Column> Columns { get; set; } = new List<Column>();
    }
}