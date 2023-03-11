using MediatR;
using UniEye.Modules.Students.Core.Models;
using UniEye.Modules.Students.Infrastructure;
using UniEye.Shared.Domain;

namespace UniEye.Modules.Students.App.Students.Commands.Create
{
    public class CreateStudentCommand: IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GroupId { get; set; }
        public int PaymentTermId { get; set; }
    }

    public class CreateStudentCommandHandle : IRequestHandler<CreateStudentCommand, int>
    {
        private readonly StudentsContext _context;

        public CreateStudentCommandHandle(StudentsContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student 
            { 
                FirstName = request.FirstName, 
                LastName = request.LastName,
                GroupId = request.GroupId, 
                PaymentTerm = Enumeration.FromValue<PaymentTerm>(request.PaymentTermId)
            };

            _context.Add(student);
            await _context.SaveChangesAsync();

            return student.Id;
        }
    }
}
