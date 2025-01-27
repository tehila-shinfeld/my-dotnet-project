using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swim.core.DTOs;
using Swim.core.Entities;
using Swim.core.Service;
using Swim.data;
namespace Swim.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
        }

        [HttpGet]
        public async Task<IEnumerable<TeacherDto>> Get()
        {
            return await teacherService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var t = await teacherService.GetByIdAsync(id);

            if (t == null)
            {
                return NotFound("id: "+id+" not found");
            }
            return Ok(t);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult> Get(string name)
        {

            var teacher = await teacherService.GetByNameAsync(name);

            if (teacher == null)
            {
                return NotFound($"student {name} not found");
            }
            return Ok(teacher);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TeacherDto t)
        {
            if (t != null)
            {
                await teacherService.AddAsync(t);
                return Ok(t);
            }
            return NotFound(t);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TeacherDto t)
        {
            TeacherDto t1 = await teacherService.ChangeAsync(id, t);
            if (t1 != null)
            {
                return Ok(t1);
            }
            return NotFound(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var t = await teacherService.DelAsync(id);
            if (t != null)
            {
                return Ok(t);
            }
            return NotFound(id);
        }
    }
}
