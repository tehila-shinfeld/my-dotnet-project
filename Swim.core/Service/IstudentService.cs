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
        public IEnumerable<StudentDto> GetAll();

        public StudentDto GetById(int id);

        public StudentDto GetByName(string name);

        public void Add(StudentDto s);

        public StudentDto Change(int id, StudentDto s);

        public StudentDto Del(int id);
    }
}
