using UniEye.Shared.App;

namespace UniEye.Modules.Students.Shared.Events
{
    public record StudentCreatedEvent: IntegrationEvent
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid Identity { get; set; }
        public string PersonalEmail { get; set; }

        public StudentCreatedEvent()
        {
        }

        public StudentCreatedEvent(string firstName, string lastName, string personalEmail, Guid identity)
        {
            FirstName = firstName;
            LastName = lastName;
            PersonalEmail = personalEmail;
            Identity = identity;
        }
    }
}
