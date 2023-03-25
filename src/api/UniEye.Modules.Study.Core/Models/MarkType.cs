using UniEye.Shared.Domain;

namespace UniEye.Modules.Study.Core.Models
{
    public class MarkType : Enumeration
    {
        public static MarkType Lecture =        new MarkType(1, "Лекція",      "LECTURE",      "Контроль на лекції");
        public static MarkType SeminarClass =   new MarkType(2, "Практична",   "SEMINAR",      "Практичне/семінарське заняття");
        public static MarkType LabClass =       new MarkType(3, "Лабораторна", "LAB",          "Лабораторна робота");
        public static MarkType IndividualWork = new MarkType(4, "Самостійна",  "INDIVIDUAL",   "Самостійна робота");
        public static MarkType Presentation =   new MarkType(5, "Доповідь",    "PRESENTATION", "Доповідь");
        public static MarkType Retake =         new MarkType(6, "Перездача",   "RETAKE",       "Перездача");
        public static MarkType ModuleWork =     new MarkType(7, "Модуль",      "MODULE",       "Модульна робота");
        public static MarkType ControlWork =    new MarkType(8, "Контрольна",  "CONTROL",      "Контрольна робота");
        public static MarkType Test =           new MarkType(9, "Тест",        "TEST",         "Тест");
        public static MarkType Colloquium =     new MarkType(10, "Колоквіум",  "COLLOQUIUM",   "Колоквіум");
        public static MarkType Exam =           new MarkType(11, "Екзамен",    "EXAM",         "Екзамен");
        public static MarkType Zalik =          new MarkType(12, "Залік",      "ZALIK",        "Залік");
        public static MarkType Other =          new MarkType(13, "Інше",       "OTHER",        "Інше");

        public MarkType(int id, string name, string code, string description) : base(id, name, code, description)
        {
        }
    }
}
