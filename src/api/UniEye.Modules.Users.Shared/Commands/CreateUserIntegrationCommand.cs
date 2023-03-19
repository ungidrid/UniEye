using System.Text.Json.Serialization;
using UniEye.Shared.App;

namespace UniEye.Modules.Users.Shared.Commands
{
    public record CreateUserIntegrationCommand : IntegrationEvent
    {
        public Guid Identity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalEmail { get; set; }

        public CreateUserIntegrationCommand()
        {
        }

        public CreateUserIntegrationCommand(
            string firstName, string lastName, 
            string personalEmail, Guid identity, 
            Guid? correlationId = null, DateTime? creationDate = null
        ): base(correlationId, creationDate)
        {
            FirstName = firstName;
            LastName = lastName;
            PersonalEmail = personalEmail;
            Identity = identity;
        }
    }
}
