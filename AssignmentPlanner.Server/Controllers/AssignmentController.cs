using AssignmentPlanner.Server.Data;
using AssignmentPlanner.Server.DTOs;
using AssignmentPlanner.Server.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Reflection.Metadata.Ecma335;

namespace AssignmentPlanner.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssignmentController : Controller
    {
        private readonly DatabaseContext _db;
        private readonly IMapper _mapper;

        //private 
        public AssignmentController(DatabaseContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            //_mapper = mapper;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok();
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            var assignments = _mapper.Map<List<AssignmentDTO>>(_db.Assignments);
            return Ok(assignments);
        }

        [HttpPost()]
        public async Task<ActionResult<AssignmentDTO>> Create(AssignmentDTO newAssignment)
        {
            Console.WriteLine("Creating assignment: " + newAssignment.Title);
            var createdAssignment = await _db.Assignments.AddAsync(_mapper.Map<Assignment>(newAssignment));
            await _db.SaveChangesAsync();
            Console.WriteLine(createdAssignment);
            return _mapper.Map<AssignmentDTO>(createdAssignment.Entity);
        }

        [HttpPut()]
        public IActionResult Update()
        {
            return Ok();
        }

        [HttpDelete()]
        public IActionResult Delete(int id)
        {
            return Ok();
        }


    }
}
