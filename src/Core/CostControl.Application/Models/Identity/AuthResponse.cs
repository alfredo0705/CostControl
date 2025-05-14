namespace CostControl.Application.Models.Identity
{
    public class AuthResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<string> Role { get; set; }
        public string Token { get; set; }
    }
}
