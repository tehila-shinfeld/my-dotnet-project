using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swim.core.DTOs;
using Swim.core.Entities;
using Swim.core.Service;
using Swim.Service;
namespace Swim.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StudentController : ControllerBase
    {
        private readonly IstudentService studentsData;

        public StudentController(IstudentService studentsD)
        {
            studentsData = studentsD;
        }
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<StudentDto>> Get()
        {
            return await studentsData.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            StudentDto s = await studentsData.GetByIdAsync(id);
            if (s == null)
            {
                return NotFound(id);
            }
            return Ok(s);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult> Get(string name)
        {
            StudentDto s = await studentsData.GetByNameAsync(name);
            if (s == null)
            {
                return NotFound($"student {name} not found");
            }
            return Ok(s);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] StudentDto s)
        {
            if (s != null)
            {
                studentsData.AddAsync(s);
                return Ok(s);
            }
            return NotFound(s);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] StudentDto s)
        {
            StudentDto s1 = await studentsData.ChangeAsync(id, s);
            if (s1 != null)
            {
                return Ok(s1);
            }
            return NotFound(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var s = await studentsData.DelAsync(id);
            if (s != null)
            {
                return Ok(s);
            }
            return NotFound(id);
        }
    }
}