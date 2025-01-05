using AutoMapper;
using Swim.core.DTOs;
using Swim.core.Entities;
using Swim.core.Repositories;
using Swim.core.Service;
using Swim.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swim.service
{
    public class CourceService : ICourseService
    {
        private readonly ICourseRepository courseRepository;
        private readonly IRepositoryManager repositoryManager;
        public readonly IMapper mapper;


        public CourceService(ICourseRepository courseRepository, IRepositoryManager repositoryManager, IMapper mapper)
        {
            this.courseRepository = courseRepository;
            this.repositoryManager = repositoryManager;
            this.mapper = mapper;
        }

        public IEnumerable<CourseDto> GetAll()
        {
            var course = courseRepository.GetAllCourses();
            var courseDto = mapper.Map<IEnumerable<CourseDto>>(course);
            return courseDto;
        }


        public CourseDto GetById(int id)
        {
            var course = courseRepository.GetCourseById(id);
            var courseDto = mapper.Map<CourseDto>(course);
            return courseDto;
        }

        public CourseDto GetByType(string type)
        {
            var course = courseRepository.GetCourseByType(type);
            var courseDto = mapper.Map<CourseDto>(course);
            return courseDto;
        }

        public void Add(CourseDto c)
        {
            var course = mapper.Map<Course>(c);
            courseRepository.AddCourse(course);
            repositoryManager.Save();
        }

        public CourseDto Change(int id, CourseDto c)
        {
            var course = mapper.Map<Course>(c);
            var cc = courseRepository.ChangeCourse(id, course);
            var dto = mapper.Map<CourseDto>(cc);
            repositoryManager.Save();
            return dto;
        }

        public CourseDto Del(int id)
        {

            var c = courseRepository.Delete(id);
            var SDTO = mapper.Map<CourseDto>(c);
            repositoryManager.Save();
            return SDTO;
        }
    }
}
