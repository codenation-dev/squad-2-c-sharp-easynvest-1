using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CentralDeErros.Api.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
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
    //[Authorize]
    public class UsersController : ControllerBase
    {
        private readonly ErrorDbContext _context;

        public UsersController(ErrorDbContext context)
        {
            _context = context;
        }


        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

       
        
        public Users BuildToken(Users user)
        {
    
            var key = Encoding.ASCII.GetBytes("AppSettings.Secret");
            var TokenHandler = new JwtSecurityTokenHandler();
            var TokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    
                   
                }),
               // Expires = DateTime.UtcNow.AddHours(2)
                
            };

            var token = TokenHandler.CreateToken(TokenDescriptor);
            user.Token = TokenHandler.WriteToken(token);
            var expiration = DateTime.UtcNow.AddHours(2);
            var emissor = ("AppSettings.Emissor");
            var validoEm = ("AppSettings.ValidoEm");
            JwtSecurityToken tks = new JwtSecurityToken(
               issuer: emissor,
               audience: validoEm
               );
       
            user.Expiration = expiration;
            return user;

        }


        [HttpPost("Login")]
        public ActionResult<Users> Login([FromBody] Users user)
        {
            var users = _context.Users.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "login inválido.");
                return BadRequest(ModelState);
            }
            else
            {
                return BuildToken(user);
            }

        }


        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, Users user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<Users>> PostUser(Users user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Users>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
