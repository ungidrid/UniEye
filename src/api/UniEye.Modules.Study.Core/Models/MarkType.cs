using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniEye.Shared.Domain;

namespace UniEye.Modules.Study.Core.Models
{
    public class MarkType : Enumeration
    {
        public static MarkType Lecture =        new MarkType(1, "Лекція",      "LECTURE",      "Контроль на лекції");
        public static MarkType SeminarClass =   new MarkType(1, "Практична",   "SEMINAR",      "Практичне/семінарське заняття");
        public static MarkType LabClass =       new MarkType(1, "Лабораторна", "LAB",          "Лабораторна робота");
        public static MarkType IndividualWork = new MarkType(1, "Самостійна",  "INDIVIDUAL",   "Самостійна робота");
        public static MarkType Presentation =   new MarkType(1, "Доповідь",    "PRESENTATION", "Доповідь");
        public static MarkType Retake =         new MarkType(1, "Перездача",   "RETAKE",       "Перездача");
        public static MarkType ModuleWork =     new MarkType(1, "Модуль",      "MODULE",       "Модульна робота");
        public static MarkType ControlWork =    new MarkType(1, "Контрольна",  "CONTROL",      "Контрольна робота");
        public static MarkType Test =           new MarkType(1, "Тест",        "TEST",         "Тест");
        public static MarkType Colloquium =     new MarkType(1, "Колоквіум",   "COLLOQUIUM",   "Колоквіум");
        public static MarkType Exam =           new MarkType(1, "Екзамен",     "EXAM",         "Екзамен");
        public static MarkType Zalik =          new MarkType(1, "Залік",       "ZALIK",        "Залік");
        public static MarkType Other =          new MarkType(1, "Інше",        "OTHER",        "Інше");

        public MarkType(int id, string name, string code, string description) : base(id, name, code, description)
        {
        }
    }
}
