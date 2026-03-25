namespace FirstAPI.Models
{
    public class AuthResult
    {
        public string Token { get; set; } = "";
        public string RefreshToken { get; set; } = "";
        public DateTime ExpiresAt { get; set; }
    }
}
