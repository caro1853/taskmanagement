using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Tasking.API.Models;

namespace Tasking.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("token")]
        public async Task<ActionResult> Token(AuthenticationInfo info)
        {
            return Ok(this.BuildToken());
        }

        private IActionResult BuildToken()
        {
            var userinfoEmail = "caro1853@gmail.com";
            var userinfoUserId = 58;
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userinfoEmail),
                new Claim("userid", userinfoUserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsAScrectKey"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(4);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "",
                audience: "",
                claims: claims,
                expires: expiration,
                signingCredentials: creds
                );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = expiration
            });
        }
	}
}

