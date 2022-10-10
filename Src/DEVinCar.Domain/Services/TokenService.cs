
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Domain.Validations.Security;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Extensions;


namespace DEVinCar.Domain.Services
{
    public static class TokenService
    {
        public static string GenerateTokenFromUser(User user)
        {
            var claims = new Claim[]
             {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Permission.GetDisplayName())
             };

            return GenerateTokenFromClaims(claims);
        }

        public static string GenerateTokenFromClaims(IEnumerable<Claim> claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Settings.Secret)),
                ValidateIssuer = false,
                ValidateAudience = false,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var secutiryToken);

            if (secutiryToken is not JwtSecurityToken jwtSecurityToken)
                throw new SecurityTokenException("Invalid token");

            return principal;
        }


        public static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        private static List<Tuple<string, string>> _refreshsTokens =
        new List<Tuple<string, string>>();

        public static List<Tuple<string, string>> GetAllRefreshTokens()
                    => _refreshsTokens;

        public static void SaveRefreshToken(string username, string refreshToken)
            => _refreshsTokens.Add(new Tuple<string, string>(username, refreshToken));

        public static string GetRefreshToken(string username)
            => _refreshsTokens.FirstOrDefault(x => x.Item1 == username).Item2;

        public static void DeleteRefreshToken(string username, string refreshToken)
        {
            var item = _refreshsTokens.FirstOrDefault(x => x.Item1 == username && x.Item2 == refreshToken);
            _refreshsTokens.Remove(item);
        }
        
    }
}