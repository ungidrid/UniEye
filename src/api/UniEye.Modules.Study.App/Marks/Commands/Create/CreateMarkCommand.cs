using MediatR;
using UniEye.Modules.Students.Shared;
using UniEye.Modules.Study.Core.Models;
using UniEye.Modules.Study.Infrastructure;

namespace UniEye.Modules.Study.App.Marks.Commands.Create
{
    public class CreateMarkCommand: IRequest<Unit>
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int Value { get; set; }
        public string? Note { get; set; }
        public int MarkTypeId { get; set; }
    }

    public class CreateMarkCommandHandler : IRequestHandler<CreateMarkCommand, Unit>
    {
        private readonly StudyContext _context;
        private readonly IStudentsClient _studentsClient;

        public CreateMarkCommandHandler(StudyContext context, IStudentsClient studentsClient)
        {
            _context = context;
            _studentsClient = studentsClient;
        }

        public async Task<Unit> Handle(CreateMarkCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentsClient.GetStudentById(request.StudentId);

            //TODO: Return meaningfull error message
            if(student == null) { return Unit.Value; }

            var mark = new Mark
            {
                StudentId = student.Id,
                SubjectId = request.SubjectId,
                MarkTypeId = request.MarkTypeId,
                Value = request.Value,
                Date = DateTime.UtcNow,
                Note = request.Note
            };

            _context.Add(mark);
            _context.SaveChanges();

            return Unit.Value;
        }
    }
}
