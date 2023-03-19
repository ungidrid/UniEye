using MassTransit;
using MediatR;
using UniEye.Modules.Students.Core.Models;
using UniEye.Modules.Students.Infrastructure;
using UniEye.Modules.Students.Shared.Events;

namespace UniEye.Modules.Students.App.Students.Commands.Create
{
    public class CreateStudentCommand: IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalEmail { get; set; }
        public int GroupId { get; set; }
        public int PaymentTermId { get; set; }
    }

    public class CreateStudentCommandHandle : IRequestHandler<CreateStudentCommand, int>
    {
        private readonly StudentsContext _context;
        private readonly IBus _eventBus;

        public CreateStudentCommandHandle(StudentsContext context, IBus eventBus)
        {
            _context = context;
            _eventBus = eventBus;
        }

        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student 
            { 
                FirstName = request.FirstName,
                PersonalEmail = request.PersonalEmail,
                LastName = request.LastName,
                GroupId = request.GroupId, 
                PaymentTermId = request.PaymentTermId
            };

            _context.Add(student);
            await _context.SaveChangesAsync();

            var @event = new StudentCreatedEvent(student.FirstName, student.LastName, student.PersonalEmail, student.IdentityGuid);
            await _eventBus.Publish(@event);

            return student.Id;
        }
    }
}
