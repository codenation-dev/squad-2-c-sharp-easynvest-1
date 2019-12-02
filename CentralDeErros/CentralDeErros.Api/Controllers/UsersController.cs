﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CentralDeErros.Api.Models;
using System.IdentityModel.Tokens.Jwt;
//using Microsoft.AspNetCore.Identity;
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
        //private readonly SignInManager<IdentityUser> _signInManager;
        //private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;

        public SigningCredentials SigningCredentials { get; private set; }

        public UsersController(IOptions<AppSettings> appSettings, ErrorDbContext context)
        {
            // _signInManager = signInManager;
            //_userManager = userManager;
            _appSettings = appSettings.Value;
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

        //[HttpPost("Token")]
        private Users BuildToken(Users user)
        {

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

            };

           // var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings.Secret));
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
            var expiration = DateTime.UtcNow.AddHours(2);
            var emissor = (_appSettings.Emissor);
            var validoEm = (_appSettings.ValidoEm);
            JwtSecurityToken token = new JwtSecurityToken(
               issuer: emissor,
               audience: validoEm,
               claims: claims,//regras
               expires: expiration,
               signingCredentials: SigningCredentials
               );


            return new Users()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }


        //[HttpPost("Criar")]
        //public ActionResult<Users> CreateUser([FromBody] Users model)
        //{
        //    //var user = new IdentityUser { UserName = model.Email, Email = model.Email };
        //    var user = _context.Users.SingleOrDefault(x => x.Email == model.Email && x.Password == model.Password);
        //    //var result = await _userManager.CreateAsync(user, model.Password);
        //    if (user==null) //result.Succeeded
        //    {
        //        return BuildToken(model);
        //    }
        //    else
        //    {
        //        return BadRequest("Usuário ou senha inválidos");
        //    }

        //}

        [HttpPost("Login")]
        public ActionResult<Users> Login([FromBody] Users user)
        {
            var users = _context.Users.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
            //var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password,
                 //isPersistent: false, lockoutOnFailure: false);

            if (user==null)
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