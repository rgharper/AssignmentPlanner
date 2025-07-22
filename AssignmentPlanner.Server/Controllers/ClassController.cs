using AssignmentPlanner.Server.Data;
using AssignmentPlanner.Server.DTOs;
using AssignmentPlanner.Server.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace AssignmentPlanner.Server.Controllers
{
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
        [HttpGet("get/{id}")]
        public IActionResult Get(int id)
        {
            return Ok();
        }

        [HttpGet("getall/{userid?}")]
        public IActionResult GetAll(int? userid)
        {
            var classes = _mapper.Map<List<ClassDTO>>(_db.Classes.Include(c => c.Assignments));
            return Ok(classes);
        }

        [HttpPost("create")]
        public IActionResult Create(ClassDTO newClass)
        {
            Console.WriteLine("Creating class: " + newClass.Name);
            return Ok();
        }

        [HttpPost("update")]
        public IActionResult Update()
        {
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }

        
    }
}
