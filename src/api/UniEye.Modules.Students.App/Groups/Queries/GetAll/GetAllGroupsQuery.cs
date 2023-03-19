using MediatR;
using Microsoft.EntityFrameworkCore;
using UniEye.Modules.Students.Infrastructure;
using UniEye.Shared.Domain.Domain;

namespace UniEye.Modules.Students.App.Groups.Queries.GetAll
{
    public class GetAllGroupsQuery: IRequest<IEnumerable<NameValue>>
    {
    }

    public class GetAllGroupsQueryHandler : IRequestHandler<GetAllGroupsQuery, IEnumerable<NameValue>>
    {
        private readonly StudentsContext _context;

        public GetAllGroupsQueryHandler(StudentsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NameValue>> Handle(GetAllGroupsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Groups.Select(x => new NameValue(x.Id, x.Name)).ToListAsync();
        }
    }
}
