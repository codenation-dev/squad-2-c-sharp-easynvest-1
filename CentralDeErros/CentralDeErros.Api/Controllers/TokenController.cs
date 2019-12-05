using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentralDeErros.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace CentralDeErros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ErrorDbContext _context;

        public TokenController(ErrorDbContext context)
        {
            _context = context;

        }

        

        [AllowAnonymous]//qualquer user acesse este método
        [HttpPost]
        public IActionResult RequestToken([FromBody]Users requestUser)
        {
            _context.Users.Add(requestUser);
            _context.SaveChanges();

            if (requestUser.Email == requestUser.Email && requestUser.Password == requestUser.Password)
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName, requestUser.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

                };
                var Key = Encoding.ASCII.GetBytes("AppSettings.Secret");
                var credenciais = new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256);
                var exp = DateTime.UtcNow.AddHours(2);
                var emissor = ("AppSettings.Emissor");
                var validoEm = ("AppSettings.ValidoEm");

                var token = new JwtSecurityToken(
                issuer: emissor,
                audience: validoEm,
                claims: claims,
                signingCredentials: credenciais);


                return Ok(new
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = exp

            });
                
            }
            //return RequestTokenSave(requestUser);

            return BadRequest("Credenciais Inválidas");

            
        }

        public Users RequestTokenSave(Users requestUser)
        {
            var TokenSave = _context.Users.Where(x => x.Email == requestUser.Email && x.Password == requestUser.Password).FirstOrDefault();

            if (TokenSave == null)
            {
                _context.Users.Add(requestUser);
                _context.SaveChanges();
            }
            else
            {
                TokenSave.Token = requestUser.Token;
                TokenSave.Expiration = requestUser.Expiration;

                _context.SaveChanges();


            }
            return requestUser;
        }


    }
}