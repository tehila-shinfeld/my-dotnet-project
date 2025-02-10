using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swim.core.DTOs;
using Swim.core.Entities;
using Swim.core.Service;
namespace Swim.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService courseService;

        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet]
        public async Task<IEnumerable<CourseDto>> Get()
        {
            return await courseService.GetAllAsyc();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var c = await courseService.GetByIdAsync(id);

            if (c == null)
            {
                return NotFound(id);
            }
            return Ok(c);
        }

        [HttpGet("type/{type}")]
        public async Task<ActionResult> Get(string type)
        {

            var course = await courseService.GetByTypeAsync(type);

            if (course == null)
            {
                return NotFound($"student {type} not found");
            }
            return Ok(course);
        }

        [HttpPost]
        public async Task<ActionResult>  Post([FromBody] CourseDto c)
        {
            if (c != null)
            {
               await courseService.AddAsync(c);
                return Ok(c);
            }
            return NotFound(null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CourseDto c)
        {
            var c1 = await courseService.ChangeAsync(id, c);
            if (c1 != null)
            {
                return Ok(c1);
            }
            return NotFound(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var c  =await courseService.DelAsync(id);
            if (c != null)
            {
                return Ok(c);
            }
            return NotFound(id);
        }
    }
}
