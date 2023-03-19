﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniEye.Modules.Students.App.Groups.Queries.GetAll;
using UniEye.Shared.Domain.Domain;

namespace UniEye.Modules.Students.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController: ControllerBase
    {
        private readonly IMediator _mediator;

        public GroupController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<NameValue>> GetAllGroups()
        {
            return await _mediator.Send(new GetAllGroupsQuery());
        }
    }
}
