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

        public IEnumerable<TeacherDto> GetAll()
        {
            var t = teacherRepository.GetAllTeachers();
            var tDTO = mapper.Map<IEnumerable<TeacherDto>>(t);
            return tDTO;
        }
        public TeacherDto GetById(int id)
        {
            var t = teacherRepository.GetTeacherById(id);
            var tDTO = mapper.Map<TeacherDto>(t);
            return tDTO;
        }

        public TeacherDto GetByName(string name)
        {
            var t = teacherRepository.GetTeacherByName(name);
            var tDTO = mapper.Map<TeacherDto>(t);
            return tDTO;
        }

        public void Add(TeacherDto t)
        {
            var te = mapper.Map<Teacher>(t);
            teacherRepository.AddTeacher(te);
            repositoryManager.Save();
        }

        public TeacherDto Change(int id, TeacherDto t)
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
            repositoryManager.Save();
            return dto;
        }

        public TeacherDto Del(int id)
        {
            var t = teacherRepository.Delete(id);
            var SDTO = mapper.Map<TeacherDto>(t);
            repositoryManager.Save();
            return SDTO;
        }
    }
}
