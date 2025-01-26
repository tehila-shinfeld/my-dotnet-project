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
        public IEnumerable<CourseDto> GetAll();

        public CourseDto GetById(int id);

        public CourseDto GetByType(string type);

        public void Add(CourseDto s);

        public CourseDto Change(int id, CourseDto s);

        public CourseDto Del(int id);
    }
}
