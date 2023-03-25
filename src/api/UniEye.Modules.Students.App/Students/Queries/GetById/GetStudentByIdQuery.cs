using MediatR;
using Microsoft.EntityFrameworkCore;
using UniEye.Modules.Students.Infrastructure;
using UniEye.Modules.Students.Shared.DTO;

namespace UniEye.Modules.Students.App.Students.Queries.GetById
{
    public class GetStudentByIdQuery: IRequest<StudentDto>
    {
        public int Id { get; set; }

        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentDto>
    {
        private readonly StudentsContext _context;

        public GetStudentByIdQueryHandler(StudentsContext context)
        {
            _context = context;
        }

        public async Task<StudentDto?> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _context.Students
                .Include(x => x.Group)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (student == null) { return null;  }

            return new StudentDto 
            { 
                Id = request.Id, 
                FullName = student.Name.GetFullName(), 
                GroupId = student.GroupId, 
                GroupName = student.Group.Name 
            };
        }
    }
}
