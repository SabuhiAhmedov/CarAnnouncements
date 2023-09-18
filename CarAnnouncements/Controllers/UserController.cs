using CarAnnouncements.DAL;
using CarAnnouncements.DTO;
using CarAnnouncements.Models;
using CarAnnouncements.ToDoItems;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CarAnnouncements.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly JwtOptions _options;
        public UserController(AppDbContext db, IOptions<JwtOptions> options)
        {
            _db = db;
            _options = options.Value;
        }
        #region User Register
        [HttpPost("Register")]
        public async Task<ActionResult> Register([FromForm] UserRegisterDto registerDto)
        {
            bool isExist = await _db.Users.AnyAsync(x => x.Username == registerDto.Username);
            if (isExist)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "User already exist" });
            }
            //Encryption 
            var hmac = new HMACSHA512();
            byte[] passwordSalt = hmac.Key;
            byte[] passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(registerDto.Password));

            User user = new User
            {
                Username = registerDto.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return Ok("User sign up successfully");
        }
        #endregion

        #region User Login
        [HttpPost("Login")]
        public async Task<ActionResult> Login( [FromForm]UserLoginDto loginDto)
        {
            User dbUser = await _db.Users.FirstOrDefaultAsync(x => x.Username == loginDto.Username);
            if (dbUser == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "Username or password is wrong" });

            }
            //VerifyPasswordHash
            var hmac = new HMACSHA512(dbUser.PasswordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(loginDto.Password));
            bool isEqual = computedHash.SequenceEqual(dbUser.PasswordHash);
            if (!isEqual)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = " Username or password is incorrect" });
            }

            if (_options.Key == null) throw new Exception("Key can't null");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));
            var credantials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claim = new[]
            {
                new Claim(ClaimTypes.Name,dbUser.Username),
                new Claim(ClaimTypes.NameIdentifier,dbUser.Id.ToString())
               
            };
            //Create Token
            var token = new JwtSecurityToken(_options.Issuer,
                _options.Audience,
                claim,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credantials

                );

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
       


        #endregion
    }
}
