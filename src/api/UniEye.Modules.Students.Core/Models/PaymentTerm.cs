using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniEye.Shared.Domain;

namespace UniEye.Modules.Students.Core.Models
{
    public class PaymentTerm : Enumeration
    {
        public static PaymentTerm Budget = new PaymentTerm(1, "Бюджет", "BUDGET");
        public static PaymentTerm Contract = new PaymentTerm(2, "Контракт", "CONTRACT");

        public PaymentTerm(int id, string name, string code) : base(id, name, code)
        {
        }
    }
}
