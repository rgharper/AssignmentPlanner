using AssignmentPlanner.Server.Data;
using AssignmentPlanner.Server.DTOs;
using AssignmentPlanner.Server.Model;
using AutoMapper;
using Isopoh.Cryptography.Argon2;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Net.Sockets;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace AssignmentPlanner.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DatabaseContext _db;
        private readonly IMapper _mapper;
        private readonly RandomNumberGenerator _rng = RandomNumberGenerator.Create();
        private readonly SymmetricSecurityKey _key;

        public UserController(DatabaseContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;

            // This key used to sign tokens MUST be securely stored and managed, not hardcoded in production code.
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This key is not secure"));
        }

        [HttpPost()]
        public async Task<ActionResult<UserDTO>> Register(UserDTO newUser)
        {
            // Argon2 hases passwords securely and includes salt and parameters in the hash removing the need to store separately
            var User = _mapper.Map<User>(newUser);
            User.Hash = Argon2.Hash(newUser.Password);
            var createdUser = await _db.Users.AddAsync(_mapper.Map<User>(User));
            await _db.SaveChangesAsync();
            return _mapper.Map<UserDTO>(createdUser.Entity);
        }

        [HttpGet()]
        public async Task<ActionResult<String>> Login(UserDTO loginUser)
        {
            var User = _mapper.Map<User>(loginUser);
            var existingUser = await _db.Users.Where(user => user.Email == loginUser.Email).FirstOrDefaultAsync();

            if (Argon2.Verify(existingUser.Hash,loginUser.Password)) // Verify the password using Argon2
            {
                // Initialize claim with the user's email
                var claims = new List<Claim> {
                    new Claim(JwtRegisteredClaimNames.NameId, existingUser.Email)
                };

                var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(7),
                    SigningCredentials = creds
                };

                var tokenHandler = new JwtSecurityTokenHandler();

                var token = tokenHandler.CreateToken(tokenDescriptor);

                var tokenEncoded = tokenHandler.WriteToken(token);
                return tokenEncoded;
            }
            return Unauthorized("Invalid email or password or account does not exist");
        }


    }
}
