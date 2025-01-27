using Swim.core.DTOs;
using Swim.core.Entities;
using Swim.core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swim.core.Service
{
    public interface ITeacherService
    {
        public Task<IEnumerable<TeacherDto>> GetAllAsync();

        public Task<TeacherDto> GetByIdAsync(int id);

        public Task<TeacherDto> GetByNameAsync(string name);

        public Task AddAsync(TeacherDto t);
        
        public Task<TeacherDto> ChangeAsync(int id, TeacherDto t);

        public Task<TeacherDto> DelAsync(int id);
    }
}
