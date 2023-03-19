using MassTransit;
using MassTransit.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniEye.Modules.Notifications.Shared.Commands;

namespace UniEye.Modules.Notifications.App.Consumers
{
    public class SendNotificationIntegrationCommandConsumer : IConsumer<SendNotificationIntegrationCommand>
    {
        public SendNotificationIntegrationCommandConsumer()
        {
        }

        public Task Consume(ConsumeContext<SendNotificationIntegrationCommand> context)
        {
            throw new NotImplementedException();
        }
    }
}
