using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniEye.Modules.Users.Shared.Commands;

namespace UniEye.Modules.Users.App.Consumers
{
    public class CreateUserIntegrationCommanConsumer : IConsumer<CreateUserIntegrationCommand>
    {
        public async Task Consume(ConsumeContext<CreateUserIntegrationCommand> context)
        {
            var message = context.Message;

            var userEmail = $"{message.FirstName}.{message.LastName}@lnu.edu.ua";

            //Create user in AD
        }
    }
}
