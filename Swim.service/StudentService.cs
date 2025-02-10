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
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Swim.Service
{
    public class StudentService : IstudentService
    {
        private readonly IStudentRepository studentRepository;
        private readonly IRepositoryManager repositoryManager;
        private readonly IMapper mapper;

        public StudentService(IStudentRepository studentRepository, IRepositoryManager repositoryManager, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.repositoryManager = repositoryManager;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<StudentDto>> GetAllAsync()
        {
            var list = await Task.Run(() => studentRepository.GetAllStudents());
            var listStudentsDto = mapper.Map<IEnumerable<StudentDto>>(list);
            return listStudentsDto;
        }

        public async Task<StudentDto> GetByIdAsync(int id)
        {
            var s = await Task.Run(() => studentRepository.GetStudentById(id));
            var SDTO = mapper.Map<StudentDto>(s);
            return SDTO;
        }
        public async Task<StudentDto> GetByNameAsync(string name)
        {
            var s = await Task.Run(() => studentRepository.GetStudentByName(name));
            var SDTO = mapper.Map<StudentDto>(s);
            return SDTO;
        }

        public async Task AddAsync(StudentDto s)
        {
            var student = mapper.Map<Student>(s);
            studentRepository.AddStudent(student);
           await repositoryManager.SaveAsync();
        }

        public async Task<StudentDto> ChangeAsync(int id, StudentDto s)
        {
            Student student = mapper.Map<Student>(s);
            var c = studentRepository.ChangeStudent(id, student);
            await repositoryManager.SaveAsync();
            return s;
        }

        public async Task<StudentDto> DelAsync(int id)
        {
            var s = studentRepository.Delete(id);
            var SDTO = mapper.Map<StudentDto>(s);
            await repositoryManager.SaveAsync();
            return SDTO;
        }


    }
}
