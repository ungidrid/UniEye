using MassTransit;
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
