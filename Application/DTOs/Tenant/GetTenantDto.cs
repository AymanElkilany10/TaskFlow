namespace TaskFlow.Application.DTOs.Tenant
{
    public class GetTenantDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string OwnerId { get; set; } = string.Empty;
        public string OwnerName { get; set; } = string.Empty;
        public int UserCount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
