using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.API.Common;
using TaskFlow.Application.DTOs.Tenant;
using TaskFlow.Application.Interfaces;

namespace TaskFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly ITenantService _tenantService;
        public TenantController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }


        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> CreateTenant(CreateTenantDto dto) 
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId is null)
                return Unauthorized(ApiResponse.FailureResponse("Unauthorized"));

            var result =await _tenantService.CreateTenantAsync(dto, userId);

            if (!result.IsSuccess)
                return BadRequest(ApiResponse.FailureResponse(result.Message!));

            return Ok(ApiResponse.SuccessResponse("Tenant created successfully"));
        }

        [Authorize]
        [HttpGet("{tenantId}")]
        public async Task<ActionResult<ApiResponse>> GetTenant(Guid tenantId)
        {
            var result = await _tenantService.GetTenantAsync(tenantId);

            if (!result.IsSuccess)
                return NotFound(ApiResponse<GetTenantDto>.FailureResponse(result.Message!));

            return Ok(ApiResponse<GetTenantDto>
                .SuccessResponse(result.Data as GetTenantDto, "Success"));
        }


        [Authorize]
        [HttpDelete("{tenantId}")]
        public async Task<ActionResult<ApiResponse>> DeleteTenant(Guid tenantId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId is null)
                return Unauthorized(ApiResponse.FailureResponse("Unauthorized"));

            var result = await _tenantService.DeleteTenantAsync(tenantId, userId);

            if (!result.IsSuccess)
                return BadRequest(ApiResponse.FailureResponse(result.Message!));

            return Ok(ApiResponse.SuccessResponse("Tenant deleted successfully"));
        }
    }
}
