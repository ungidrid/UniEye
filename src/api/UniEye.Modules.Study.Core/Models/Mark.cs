using UniEye.Shared.Domain;

namespace UniEye.Modules.Study.Core.Models
{
    public class Mark: IDomainModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }

        public int MarkTypeId { get; set; }
        public MarkType MarkType { get; set; }

        public int Value { get; set; }
        public DateTime Date { get; set; }
    }
}
