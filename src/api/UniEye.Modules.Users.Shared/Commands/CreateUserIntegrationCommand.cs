using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniEye.Shared.App;

namespace UniEye.Modules.Users.Shared.Commands
{
    public record CreateUserIntegrationCommand : IntegrationEvent
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public CreateUserIntegrationCommand(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
