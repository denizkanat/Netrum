namespace Infrastructure.Utilities.Token
{
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;

    public class JwtGenerator
    {
        private readonly IConfiguration _configuration;
        private Settings _tokenOptions;
        private DateTime _tokenExpiration;

        public JwtGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
            _tokenOptions = _configuration.GetSection("TokenOptions").Get<Settings>();
        }

        private JwtSecurityToken CreateJwtSecurityToken(Settings tokenOptions, SigningCredentials signingCredentials)
        {
            var jwtSecurityToken = new JwtSecurityToken
              (
               issuer: tokenOptions.Issuer,
               audience: tokenOptions.Audience,
               expires: _tokenExpiration,
               notBefore: DateTime.Now,
               claims: new List<Claim> { 
                   new Claim("KEY1", "VALUE1"), 
                   new Claim("KEY2", "VALUE2"), 
                   new Claim("KEY3", "VALUE3") },
               signingCredentials: signingCredentials
              );

            return jwtSecurityToken;
        }

        public AccessToken CreateAccessToken()
        {
            _tokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.TokenExpiration);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            var jwt = CreateJwtSecurityToken(_tokenOptions, signingCredentials);

            var jwtHandler = new JwtSecurityTokenHandler();
            var token = jwtHandler.WriteToken(jwt);

            return new AccessToken()
            {
                Token = token,
                Expiration = _tokenExpiration,
                Claims = new List<string> { "CLAIM1", "CLAIM2", "CLAIM3" }
            };
        }
    }
}
