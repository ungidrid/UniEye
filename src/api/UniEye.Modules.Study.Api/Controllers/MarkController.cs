using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniEye.Modules.Study.App.Marks.Commands.Create;

namespace UniEye.Modules.Study.Api.Controllers
{
    [ApiController]
    [Route("study/[controller]")]
    public class MarkController: ControllerBase
    {
        private readonly IMediator _mediator;

        public MarkController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task RecordMark(CreateMarkCommand command)
        {
            await _mediator.Send(command);
        }
    }
}
