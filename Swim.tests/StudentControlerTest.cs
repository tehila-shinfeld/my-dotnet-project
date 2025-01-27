using Microsoft.AspNetCore.Mvc;
using Swim.data;
using SwimSystem.Controllers;

namespace Swim.tests
{
    public class StudentControlerTest
    {
        private readonly StudentController controller;

        public StudentControlerTest()
        {
            FakeContext fakeContext = new FakeContext();

            //controller = new StudentController(fakeContext);
        }

        [Fact]
        public void GetAllStudents_Returens_NotNull()
        {
            var res = controller.Get();

            Assert.NotNull(res);
        }

        [Fact]
        public void GetAllStudents_Returens_Null()
        {
            var res = controller.Get();

            Assert.Null(res);
        }

        [Fact]
        public void GetAll_ReturnsCount()
        {
            var result = controller.Get();

            //Assert.Equal(1, result.Count());
        }

        [Fact]
        public void GetStudentById_Returens_Ok()
        {
            //arange
            var id = 1;

            //act:
            var res = controller.Get(id);

            //Assert
            Assert.IsType<OkObjectResult>(res);
        }

        [Fact]
        public void GetStudentById_Returens_NotFound()
        {
            //arange
            var id = 8;

            //act:
            var res = controller.Get(id);

            //Assert
            Assert.IsType<NotFoundObjectResult>(res);
        }

    }
}