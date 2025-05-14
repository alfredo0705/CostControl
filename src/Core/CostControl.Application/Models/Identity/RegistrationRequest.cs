using System.ComponentModel.DataAnnotations;

namespace CostControl.Application.Models.Identity
{
    public class RegistrationRequest
    {
        public string? Id { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        //[Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [MinLength(4)]
        public string UserName { get; set; }
        public string? Password { get; set; } = string.Empty;
        public string? Rol { get; set; }
        public string DocumentId { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
    }
}
