using UniEye.Shared.Domain;
using UniEye.Shared.Domain.Domain;

namespace UniEye.Modules.Students.Core.Models
{
    public class Student: IDomainModel, ISharedIdentity
    {
        public int Id { get; set; }
        public Guid IdentityGuid { get; set; } = Guid.NewGuid();

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalEmail { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }

        public int PaymentTermId { get; set; }
        public PaymentTerm PaymentTerm { get; set; }
    }
}
