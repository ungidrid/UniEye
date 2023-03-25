using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniEye.Modules.Students.App.Students.Commands.Create;
using UniEye.Modules.Students.App.Students.Queries.GetById;
using UniEye.Modules.Students.Shared.DTO;

namespace UniEye.Modules.Students.Api.Controllers
{
    [ApiController]
    [Route("students/[controller]")]
    public class StudentController: ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<StudentDto> GetStudentById(int id)
        {
            var query = new GetStudentByIdQuery(id);
            var result = await _mediator.Send(query);
            return result;
        }


        [HttpPost]
        public async Task<int> CreateStudent(CreateStudentCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
