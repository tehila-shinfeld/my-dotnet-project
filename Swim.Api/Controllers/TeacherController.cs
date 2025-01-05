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
        public IEnumerable<TeacherDto> Get()
        {
            return teacherService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var t = teacherService.GetById(id);

            if (t == null)
            {
                return NotFound(id);
            }
            return Ok(t);
        }

        [HttpGet("name/{name}")]
        public ActionResult Get(string name)
        {

            var teacher = teacherService.GetByName(name);

            if (teacher == null)
            {
                return NotFound($"student {name} not found");
            }
            return Ok(teacher);
        }

        [HttpPost]
        public ActionResult Post([FromBody] TeacherDto t)
        {
            if (t != null)
            {
                teacherService.Add(t);
                return Ok(t);
            }
            return NotFound(t);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TeacherDto t)
        {
            TeacherDto t1 = teacherService.Change(id, t);
            if (t1 != null)
            {
                return Ok(t1);
            }
            return NotFound(id);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var t = teacherService.Del(id);
            if (t != null)
            {
                return Ok(t);
            }
            return NotFound(id);
        }
    }
}
