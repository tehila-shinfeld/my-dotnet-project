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
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository teacherRepository;
        private readonly IRepositoryManager repositoryManager;
        private readonly IMapper mapper;

        public TeacherService(ITeacherRepository teacherRepository, IRepositoryManager repositoryManager, IMapper mapper)
        {
            this.teacherRepository = teacherRepository;
            this.repositoryManager = repositoryManager;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<TeacherDto>> GetAllAsync()
        {
            var t = await Task.Run(() => teacherRepository.GetAllTeachers());
            var tDTO = mapper.Map<IEnumerable<TeacherDto>>(t);
            return tDTO;
        }
        public async Task<TeacherDto> GetByIdAsync(int id)
        {
            var t = await Task.Run(() => teacherRepository.GetTeacherById(id));
            var tDTO = mapper.Map<TeacherDto>(t);
            return tDTO;
        }

        public async Task<TeacherDto> GetByNameAsync(string name)
        {
            var t = await Task.Run(() => teacherRepository.GetTeacherByName(name));
            var tDTO = mapper.Map<TeacherDto>(t);
            return tDTO;
        }

        public async Task AddAsync(TeacherDto t)
        {
            var te = mapper.Map<Teacher>(t);
            teacherRepository.AddTeacher(te);
            await repositoryManager.SaveAsync();
        }

        public async Task<TeacherDto> ChangeAsync(int id, TeacherDto t)
        {
            if (t == null)
            {
                throw new ArgumentNullException(nameof(t), "The TeacherDto cannot be null.");
            }
            if (id <= 0)
            {
                throw new ArgumentException("The id must be greater than zero.", nameof(id));
            }
            var tt = mapper.Map<Teacher>(t);
            var te = teacherRepository.ChangeTeacher(id, tt);
            var dto = mapper.Map<TeacherDto>(te);
            await repositoryManager.SaveAsync();
            return dto;
        }

        public async Task<TeacherDto> DelAsync(int id)
        {
            var t = teacherRepository.Delete(id);
            var SDTO = mapper.Map<TeacherDto>(t);
            await repositoryManager.SaveAsync();
            return SDTO;
        }
    }
}
