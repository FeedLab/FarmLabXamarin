namespace FarmLabDevice.Model
{
    public class Jwt
    {
        public string Id { get; set; }
        public string Token { get; set; }
        public int ExpiresInSeconds { get; set; }
    }
}
