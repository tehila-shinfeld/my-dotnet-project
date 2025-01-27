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

        public async Task<IEnumerable<CourseDto>> GetAllAsyc()
        {
            var courses = await Task.Run(() => courseRepository.GetAllCourses());
            var courseDto = mapper.Map<IEnumerable<CourseDto>>(courses);
            return courseDto;
        }

        public async Task<CourseDto> GetByIdAsync(int id)
        {
            var course = await Task.Run(() => courseRepository.GetCourseById(id));
            var courseDto = mapper.Map<CourseDto>(course);
            return courseDto;
        }

        public async Task<CourseDto> GetByTypeAsync(string type)
        {
            var course = await Task.Run(() => courseRepository.GetCourseByType(type));
            var courseDto = mapper.Map<CourseDto>(course);
            return courseDto;
        }

        public async Task AddAsync(CourseDto c)
        {
            var course = mapper.Map<Course>(c);
            courseRepository.AddCourse(course);
            repositoryManager.SaveAsync();
        }

        public async Task<CourseDto> ChangeAsync(int id, CourseDto c)
        {
            var course = mapper.Map<Course>(c);
            var cc = courseRepository.ChangeCourse(id, course);
            var dto = mapper.Map<CourseDto>(cc);
            repositoryManager.SaveAsync();
            return dto;
        }

        public async Task<CourseDto> DelAsync(int id)
        {

            var c = courseRepository.Delete(id);
            var SDTO = mapper.Map<CourseDto>(c);
            repositoryManager.SaveAsync();
            return SDTO;
        }

    }
}
