using TaskFlow.Application.Common;
using TaskFlow.Application.DTOs.Tenant;

namespace TaskFlow.Application.Interfaces
{
    public interface ITenantService
    {
        Task<ServiceResult> CreateTenantAsync(CreateTenantDto dto, string ownerId);
        Task<ServiceResult> GetTenantAsync(Guid tenantId);
        Task<ServiceResult> DeleteTenantAsync(Guid tenantId, string UserId);
    }
}
