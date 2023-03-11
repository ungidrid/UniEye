using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniEye.Modules.Students.App.Students.Commands.Create;

namespace UniEye.Modules.Students.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController: ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<int> CreateStudent(CreateStudentCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
