using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Survive.Api.Auth.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Survive.Api.Auth
{
    public static class AuthApi
    {
        public static void Register(WebApplication app, WebApplicationBuilder builder)
        {
            var api = app.MapGroup("security");

            api.MapGet("/getMessage",
                () => "Hello World!").RequireAuthorization();


            api.MapPost("/createToken",
            [AllowAnonymous] (User user) =>
            {
                if (user.UserName == "admin" && user.Password == "admin")
                {
                    var issuer = builder.Configuration["Jwt:Issuer"];
                    var audience = builder.Configuration["Jwt:Audience"];
                    var key = Encoding.ASCII.GetBytes
                    (builder.Configuration["Jwt:Key"]);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new[]
                        {
                new Claim("Id", Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString())
                        }),
                        Expires = DateTime.UtcNow.AddMinutes(5),
                        Issuer = issuer,
                        Audience = audience,
                        SigningCredentials = new SigningCredentials
                        (new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha512Signature)
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var jwtToken = tokenHandler.WriteToken(token);
                    var stringToken = tokenHandler.WriteToken(token);
                    return Results.Ok(stringToken);
                }
                return Results.Unauthorized();
            });
        }
    }
}
