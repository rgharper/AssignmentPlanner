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

        //[HttpPost()]
        //public async Task<ActionResult<AssignmentDTO>> Create(RegisterDTO newUser)
        //{
        //    // Argon2 hases passwords securely and includes salt and parameters in the hash removing the need to store separately
        //    var hash = Argon2.Hash(newUser.Password);
        //    var createdUser = await _db.Assignments.AddAsync(_mapper.Map<Assignment>(newAssignment));
        //    await _db.SaveChangesAsync();
        //    Console.WriteLine(createdAssignment);
        //    return _mapper.Map<AssignmentDTO>(createdAssignment.Entity);
        //}
    }
}
