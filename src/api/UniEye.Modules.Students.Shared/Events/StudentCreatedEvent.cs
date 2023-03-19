using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniEye.Shared.App;

namespace UniEye.Modules.Students.Shared.Events
{
    public record StudentCreatedEvent: IntegrationEvent
    {
        public string FirstName { get; }
        public string LastName { get; }

        public StudentCreatedEvent(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
