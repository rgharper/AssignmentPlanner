using AssignmentPlanner.Server.Data;
using AssignmentPlanner.Server.DTOs;
using AssignmentPlanner.Server.Model;
using AssignmentPlanner.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssignmentPlanner.Server.Controllers
{
    [Route("[controller]")]
    public class ClassController : Controller
    {
        private readonly DatabaseContext _db;
        public ClassController(DatabaseContext db)
        {
            _db = db;
        }
        [HttpGet("get/{id}")]
        public IActionResult Get(int id)
        {
            return Ok();
        }

        [HttpGet("getall/{userid?}")]
        public IActionResult GetAll(int? userid)
        {
            Console.WriteLine("Adding fake classes and assignments...");
            for (int i = 1; i <= 6; i++)
            {
                var newAssignments = new List<Assignment>();
                for (int j = 1; j <= 3; j++)
                {
                    newAssignments.Add(new Assignment
                    {
                        Title = $"Assignment {j}",
                        Desciption = $"Assignment {j} for class {i}.",
                        Date = DateTime.Now.AddDays(j),
                        ClassId = i

                    });
                }
                _db.Add(new Class
                {
                    Name = $"Class {i}",
                    Assignments = newAssignments,
                });
            }
            _db.SaveChanges();
            //Console.WriteLine("Query from the database...");
            //var classList = _db.Classes.Include(c => c.Assignments).ToList();
            //Console.WriteLine("Classes and their assignments:");
            //foreach (var c in classList)
            //{
            //    Console.WriteLine($"Class: {c.Name}");
            //    foreach (var a in c.Assignments)
            //    {
            //        Console.WriteLine($"  Assignment: {a.Title}, Description: {a.Desciption}, Date: {a.Date}");
            //    }
            //}
            var classes = _db.Classes.Include(c => c.Assignments);
            return Ok(classes);
        }

        [HttpPost("create")]
        public IActionResult Create()
        {
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
