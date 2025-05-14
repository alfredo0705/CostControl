using Microsoft.AspNetCore.Identity;

namespace CostControl.Identity.Entities
{
    public class AppRole : IdentityRole<int>
    {
        public virtual ICollection<AppUserRole> UserRoles { get; set; } = new List<AppUserRole>();
    }
}
