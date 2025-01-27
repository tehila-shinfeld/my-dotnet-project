using Swim.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Swim.core.Repositories
{
    public interface IRepositoryManager
    {
        IStudentRepository StudentRepository { get; }

        ITeacherRepository TeacherRepository { get; }

        ICourseRepository CourseRepository { get; }

        public  Task SaveAsync();
    }
}