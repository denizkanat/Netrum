namespace Infrastructure.Utilities.Token;

using System.Security.Claims;

public class AccessToken
{
          public IEnumerable<string> Claims { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
}