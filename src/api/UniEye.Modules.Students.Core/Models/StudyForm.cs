using UniEye.Shared.Domain;

namespace UniEye.Modules.Students.Core.Models
{
    public class StudyForm : Enumeration
    {
        public static StudyForm FullTime = new StudyForm(1, "Денна", "FULL_TIME");
        public static StudyForm External = new StudyForm(2, "Заочна", "EXTERNAL");

        public StudyForm(int id, string name, string code) : base(id, name, code)
        {
        }
    }
}
