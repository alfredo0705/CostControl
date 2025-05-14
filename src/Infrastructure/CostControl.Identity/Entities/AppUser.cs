using CostControl.Identity.ValueObjects.AppUser;
using Microsoft.AspNetCore.Identity;

namespace CostControl.Identity.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public virtual ICollection<AppUserRole>? UserRoles { get; set; } = new List<AppUserRole>();
        public string DocumentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
    }
}