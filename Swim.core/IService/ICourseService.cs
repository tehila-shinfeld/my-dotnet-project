using Swim.core.DTOs;
using Swim.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swim.core.Service
{
    public interface ICourseService
    {
        public  Task<IEnumerable<CourseDto>> GetAllAsyc();

        public Task<CourseDto> GetByIdAsync(int id);

        public  Task<CourseDto> GetByTypeAsync(string type);

        public Task AddAsync(CourseDto c);

        public Task<CourseDto> ChangeAsync(int id, CourseDto c);

        public Task<CourseDto> DelAsync(int id);
    }
}
