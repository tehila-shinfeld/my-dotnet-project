using Microsoft.EntityFrameworkCore;
using Swim.core;
using Swim.core.Entities;
using Swim.core.Repositories;
using Swim.core.Service;
using Swim.Core.Repositories;
using Swim.data;
using Swim.data.Repositories;
using Swim.service;
using Swim.Service;
using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);
//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<DataContext>();
//    context.Database.Migrate(); // ����� ��������
//    if (!context.students.Any())
//    {
//        context.students.AddRange(
//            new Student { FirstName = "Alice", Age = 20 },
//            new Student { FirstName = "Bob", Age = 22 }
//        );
//        context.SaveChanges();
//    }
//}
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

builder.Services.AddSwaggerGen();

//builder.Services.AddSingleton<IDataContext, DataContext>();
builder.Services.AddDbContext<DataContext>();

builder.Services.AddScoped<IstudentService, StudentService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();

builder.Services.AddScoped<ICourseService, CourceService>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddAutoMapper(typeof(Mapping));

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

