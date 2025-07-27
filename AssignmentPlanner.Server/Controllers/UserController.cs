using AssignmentPlanner.Server.Data;
using AssignmentPlanner.Server.DTOs;
using AssignmentPlanner.Server.Model;
using AutoMapper;
using Isopoh.Cryptography.Argon2;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace AssignmentPlanner.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DatabaseContext _db;
        private readonly IMapper _mapper;
        private readonly RandomNumberGenerator _rng = RandomNumberGenerator.Create();

        public UserController(DatabaseContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpPost()]
        public async Task<ActionResult<UserDTO>> Register(UserDTO newUser)
        {
            // Argon2 hases passwords securely and includes salt and parameters in the hash removing the need to store separately
            var User = _mapper.Map<User>(newUser);
            User.Hash = Argon2.Hash(newUser.Password);
            var createdUser = await _db.Users.AddAsync(_mapper.Map<User>(newUser));
            await _db.SaveChangesAsync();
            return _mapper.Map<UserDTO>(createdUser.Entity);
        }


    }
}
