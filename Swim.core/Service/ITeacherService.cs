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
        public IEnumerable<TeacherDto> GetAll();

        public TeacherDto GetById(int id);

        public TeacherDto GetByName(string name);

        public void Add(TeacherDto t);

        public TeacherDto Change(int id, TeacherDto t);

        public TeacherDto Del(int id);
    }
}
