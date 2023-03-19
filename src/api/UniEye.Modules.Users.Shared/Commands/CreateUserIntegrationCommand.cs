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
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public CreateUserIntegrationCommand(string firstName, string lastName, Guid? correlationId = null, DateTime? creationDate = null): base(correlationId, creationDate)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        [JsonConstructor]
        public CreateUserIntegrationCommand(string firstName, string lastName, Guid correlationId, DateTime creationDate) : 
            this(firstName, lastName, (Guid?)correlationId, creationDate)
        {
        }
    }
}
