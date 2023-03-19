using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UniEye.Shared.App;

namespace UniEye.Modules.Users.Shared.Commands
{
    public record CreateUserIntegrationCommand : IntegrationEvent
    {
        [JsonInclude]
        public string FirstName { get; set; }
        [JsonInclude]
        public string LastName { get; set; }

        public CreateUserIntegrationCommand(string firstName, string lastName, Guid? correlationId = null): base(correlationId)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        [JsonConstructor]
        public CreateUserIntegrationCommand(string firstName, string lastName, Guid correlationId, DateTime creationDate) : base(correlationId, creationDate)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
