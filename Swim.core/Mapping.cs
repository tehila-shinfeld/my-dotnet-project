using AutoMapper;
using Swim.core.DTOs;
using Swim.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swim.core
{
    public class Mapping:Profile
    {

        public Mapping()
        {

            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();
            //.ForMember(dest => dest.TeacherId, opt => opt.MapFrom(src => src. ?? "DefaultValue"));
            CreateMap<Teacher, TeacherDto>().ReverseMap();
        }
    }
}
