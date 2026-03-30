using Microsoft.AspNetCore.Identity;

namespace TaskFlow.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public ICollection<TenantUser> TenantUsers { get; set; } = new List<TenantUser>();
        public ICollection<UserProject> UserProjects { get; set; } = new List<UserProject>();
        public ICollection<TaskAssignee> TaskAssignees { get; set; } = new List<TaskAssignee>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    }
}