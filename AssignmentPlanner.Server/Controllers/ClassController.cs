using Microsoft.AspNetCore.Mvc;
using AssignmentPlanner.Server.DTOs;
using AssignmentPlanner.Server.Services;

namespace AssignmentPlanner.Server.Controllers
{
    [Route("[controller]")]
    public class ClassController : Controller
    {
        [HttpGet("get/{id}")]
        public IActionResult Get(int id)
        {
            return Ok();
        }

        [HttpGet("getall/{userid?}")]
        public IActionResult GetAll(int? userid)
        {
            var classService = new ClassService();
            var classes = classService.GetClasses(userid);
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
