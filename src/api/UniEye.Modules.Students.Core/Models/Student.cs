using UniEye.Shared.Domain;

namespace UniEye.Modules.Students.Core.Models
{
    public class Student: IDomainModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }

        public int PaymentTermId { get; set; }
        public PaymentTerm PaymentTerm { get; set; }
    }
}
