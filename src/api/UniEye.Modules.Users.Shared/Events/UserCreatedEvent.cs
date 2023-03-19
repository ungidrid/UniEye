using System.Text.Json.Serialization;
using UniEye.Shared.App;

namespace UniEye.Modules.Users.Shared.Events
{
    public record UserCreatedEvent : IntegrationEvent
    {
        public Guid Identity { get; }
        public string DisplayName { get; }
        public string DomainName { get; }
        public string FirstLoginPassword { get; }

        public UserCreatedEvent(
            string displayName, string domainName, 
            string firstLoginPassword, Guid identity,
            Guid? correlationId = null, DateTime? creationDate = null
        ) : base(correlationId, creationDate)
        {
            DisplayName = displayName;
            DomainName = domainName;
            FirstLoginPassword = firstLoginPassword;
            Identity = identity;
        }

        public UserCreatedEvent()
        {
        }
    }
}
