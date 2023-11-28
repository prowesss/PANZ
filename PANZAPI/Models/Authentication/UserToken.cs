namespace PANZAPI.Models.Authentication
{
    public class UserToken
    {
        public string Id { get; set; }
        public string userName { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public bool IsAdmin { get; set; }
    }
}
