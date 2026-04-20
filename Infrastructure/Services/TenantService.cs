using Microsoft.EntityFrameworkCore;
using TaskFlow.Application.Common;
using TaskFlow.Application.DTOs.Tenant;
using TaskFlow.Application.Interfaces;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Enums;
using TaskFlow.Infrastructure.Data;

namespace TaskFlow.Infrastructure.Services
{
    public class TenantService : ITenantService
    {
        private readonly ApplicationDbContext _context;

        public TenantService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResult> CreateTenantAsync(CreateTenantDto dto, string ownerId)
        {

            if (await _context.Tenants.AnyAsync(t => t.Slug == dto.Slug))
            {
                return ServiceResult.FailureResult("Slug already exists.");
            }

            if (await _context.Users.FindAsync(ownerId) == null)
            {
                return ServiceResult.FailureResult("Owner not found.");
            }

            var tenant = new Tenant
            {
                Name = dto.Name,
                Slug = dto.Slug,
                OwnerId = ownerId,
            };

            var tenantUser = new TenantUser
            {
                TenantId = tenant.Id,
                UserId = ownerId,
                Role = TenantRole.Admin
            };

            _context.Tenants.Add(tenant);
            _context.TenantUsers.Add(tenantUser);
            await _context.SaveChangesAsync();
            return ServiceResult.SuccessResult();
        }
        
        public async Task<ServiceResult> GetTenantAsync(Guid tenantId)
        {
            var tenant = await _context.Tenants
                .Include(t => t.TenantUsers)
                .ThenInclude(tu => tu.User)
                .FirstOrDefaultAsync(t => t.Id == tenantId);

            if (tenant == null)
                return ServiceResult.FailureResult("Tenant not found.");

            var tenantDto = new GetTenantDto
            {
                Id = tenant.Id,
                Name = tenant.Name,
                Slug = tenant.Slug,
                OwnerId = tenant.OwnerId,
                OwnerName = tenant.TenantUsers.FirstOrDefault(tu => tu.UserId == tenant.OwnerId)?.User.UserName ?? "Unknown",
                UserCount = tenant.TenantUsers.Count,
                CreatedAt = tenant.CreatedAt
            };

            return  ServiceResult.SuccessResult(tenantDto);
        }

        public async Task<ServiceResult> DeleteTenantAsync(Guid tenantId, string userId)
        {
            var tenant = await _context.Tenants
                .Include(t => t.TenantUsers)
                .FirstOrDefaultAsync(t => t.Id == tenantId);

            if (tenant == null)
                return ServiceResult.FailureResult("Tenant not found.");

            var tenantUser = tenant.TenantUsers.FirstOrDefault(tu => tu.UserId == userId);

            if (tenantUser == null || tenantUser.Role != TenantRole.Admin)
                return ServiceResult.FailureResult("UnAuthorized..!!");

            tenant.IsDeleted = true;
            tenant.DeletedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return ServiceResult.SuccessResult();

        }

        
    }
}
