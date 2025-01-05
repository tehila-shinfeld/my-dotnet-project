using Microsoft.AspNetCore.Mvc;
using Swim.core.DTOs;
using Swim.core.Entities;
using Swim.core.Service;
namespace Swim.Api.Controllers
{
    // i am :)
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService courseService;

        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet]
        public IEnumerable<CourseDto> Get()
        {
            return courseService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var c = courseService.GetById(id);

            if (c == null)
            {
                return NotFound(id);
            }
            return Ok(c);
        }

        [HttpGet("type/{type}")]
        public ActionResult Get(string type)
        {

            var course = courseService.GetByType(type);

            if (course == null)
            {
                return NotFound($"student {type} not found");
            }
            return Ok(course);
        }

        [HttpPost]
        public ActionResult Post([FromBody] CourseDto c)
        {
            if (c != null)
            {
                courseService.Add(c);
                return Ok(c);
            }
            return NotFound(null);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CourseDto c)
        {
            var c1 = courseService.Change(id, c);
            if (c1 != null)
            {
                return Ok(c1);
            }
            return NotFound(id);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var c = courseService.Del(id);
            if (c != null)
            {
                return Ok(c);
            }
            return NotFound(id);
        }
    }
}
