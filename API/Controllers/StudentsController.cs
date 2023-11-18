using Domain.MockDomain;
using Domain.Student;
using Microsoft.AspNetCore.Mvc;
using Application.Students;

namespace API.Controllers
{
    public class StudentsController : BaseApiController
    {
        [HttpGet]
        public async Task<List<Student>> GetStudents()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<Student> GetStudent(Guid id)
        {
            return await Mediator.Send(new Details.Query { Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(Student student)
        {
            await Mediator.Send(new Create.Command { Student = student });
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditStudent(Guid id, Student student)
        {
            student.Id = id;
            await Mediator.Send(new Edit.Command { Student = student });

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            await Mediator.Send((new Delete.Command { Id = id }));

            return Ok();
        }



    }
}
