using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UniEye.Shared.App;

namespace UniEye.Modules.Users.Shared.Events
{
    public record UserCreatedEvent : IntegrationEvent
    {
        public string PersonalEmail { get; }
        public string DisplayName { get; }
        public string DomainName { get; }
        public string FirstLoginPassword { get; }

        public UserCreatedEvent(string personalEmail, string displayName, string domainName, string firstLoginPassword, Guid? correlationId = null, DateTime? creationDate = null) : base(correlationId, creationDate)
        {
            PersonalEmail = personalEmail;
            DisplayName = displayName;
            DomainName = domainName;
            FirstLoginPassword = firstLoginPassword;
        }

        [JsonConstructor]
        public UserCreatedEvent(string personalEmail, string displayName, string domainName, string firstLoginPassword, Guid correlationId, DateTime creationDate) : 
            this(personalEmail, displayName, domainName, firstLoginPassword, (Guid?)correlationId, creationDate)
        {
        }
    }
}
