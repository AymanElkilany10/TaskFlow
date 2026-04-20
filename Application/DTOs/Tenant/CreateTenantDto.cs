namespace TaskFlow.Application.DTOs.Tenant
{
    public class CreateTenantDto
    {
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
    }
}
