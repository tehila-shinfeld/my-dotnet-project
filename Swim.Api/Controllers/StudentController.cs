using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swim.core.DTOs;
using Swim.core.Entities;
using Swim.core.Service;
using Swim.Service;
namespace SwimSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StudentController : ControllerBase
    {
        private readonly IstudentService studentsData;

        public StudentController(IstudentService studentsD)
        {
            this.studentsData = studentsD;
        }

        [HttpGet]
        public IEnumerable<StudentDto> Get()
        {            
            return studentsData.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            StudentDto s = studentsData.GetById(id);
            if (s == null)
            {
                return NotFound(id);
            }
            return Ok(s);
        }

        [HttpGet("name/{name}")]
        public ActionResult Get(string name)
        {
            StudentDto s = studentsData.GetByName(name);
            if (s == null)
            {
                return NotFound($"student {name} not found");
            }
            return Ok(s);
        }

        [HttpPost]
        public ActionResult Post([FromBody] StudentDto s)
        {
            if (s != null)
            {
                studentsData.Add(s);
                return Ok(s);
            }
            return NotFound(s);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] StudentDto s)
        {
            StudentDto s1 = studentsData.Change(id, s);
            if (s1 != null)
            {
                return Ok(s1);
            }
            return NotFound(id);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var s = studentsData.Del(id);
            if (s != null)
            {
                return Ok(s);
            }
            return NotFound(id);
        }
    }
}