using AssignmentPlanner.Server.Data;
using AssignmentPlanner.Server.DTOs;
using AssignmentPlanner.Server.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace AssignmentPlanner.Server.Controllers
{
    [Authorize] // Require authorization for modifying classes
    [ApiController]
    [Route("[controller]")]
    public class ClassController : Controller
    {
        private readonly DatabaseContext _db;
        private readonly IMapper _mapper;

        //private 
        public ClassController(DatabaseContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            //_mapper = mapper;
        }

        [HttpGet()]
        public IActionResult GetAll(int? userid)
        {
            var userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var classes = _mapper.Map<List<ClassDTO>>(_db.Classes.Where(c => c.UserId == userId).Include(c => c.Assignments));
            return Ok(classes);
        }

        [HttpPost()]
        public async Task<ActionResult<ClassDTO>> Create(ClassDTO newClass)
        {
            var userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            Console.WriteLine("Creating assignment: " + newClass.Name);
            newClass.UserId = userId; // Set the UserId from the authenticated user 
            var createdClass = await _db.Classes.AddAsync(_mapper.Map<Class>(newClass));
            await _db.SaveChangesAsync();
            Console.WriteLine(createdClass);
            return _mapper.Map<ClassDTO>(createdClass.Entity);
        }

        [HttpPut()]
        public IActionResult Update()
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            return Ok();
        }

        
    }
}
