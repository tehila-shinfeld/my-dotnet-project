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

        public IEnumerable<StudentDto> GetAll()
        {
            var list = studentRepository.GetAllStudents();
            var listStudentsDto=mapper.Map<IEnumerable<StudentDto>>(list);
            return listStudentsDto;
        }

        public StudentDto GetById(int id)
        {
            var s = studentRepository.GetStudentById(id);
            var SDTO = mapper.Map<StudentDto>(s);
            return SDTO;
        }
        public StudentDto GetByName(string name)
        {
            var s =  studentRepository.GetStudentByName(name);
            var SDTO = mapper.Map<StudentDto>(s);
            return SDTO;
        }
        
        public void Add(StudentDto s)
        {
            var student = mapper.Map<Student>(s);
            studentRepository.AddStudent(student);
            repositoryManager.Save();
        }

        public StudentDto Change(int id, StudentDto s)
        {
            Student student = mapper.Map<Student>(s);
            var c = studentRepository.ChangeStudent(id, student);
            repositoryManager.Save();
            return s;
        }
        
        public StudentDto Del(int id)
        {
            var s = studentRepository.Delete(id);
            var SDTO = mapper.Map<StudentDto>(s);
            repositoryManager.Save();
            return SDTO;
        }

   
    }
}
