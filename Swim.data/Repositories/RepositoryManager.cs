using Swim.core.Repositories;
using Swim.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swim.data.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly DataContext data;

        public IStudentRepository StudentRepository { get; }

        public ITeacherRepository TeacherRepository { get; }

        public ICourseRepository CourseRepository { get; }

        public RepositoryManager(DataContext dataContext
            , ITeacherRepository teacherRepository,
            IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            data = dataContext;
            StudentRepository = studentRepository;
            TeacherRepository = teacherRepository;
            CourseRepository = courseRepository;
        }

        public async Task SaveAsync()
        {
            await data.SaveChangesAsync();
        }

    }
}
