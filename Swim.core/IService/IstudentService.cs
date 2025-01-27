using Swim.core.DTOs;
using Swim.core.Entities;
using Swim.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swim.core.Service
{
    public interface IstudentService
    {
        public Task<IEnumerable<StudentDto>> GetAllAsync();

        public Task<StudentDto> GetByIdAsync(int id);

        public Task<StudentDto> GetByNameAsync(string name);

        public Task AddAsync(StudentDto s);

        public Task<StudentDto> ChangeAsync(int id, StudentDto s);

        public Task<StudentDto> DelAsync(int id);
    }
}