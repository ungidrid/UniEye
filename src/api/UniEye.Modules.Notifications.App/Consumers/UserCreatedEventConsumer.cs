using MassTransit;
using UniEye.Modules.Users.Shared.Events;

namespace UniEye.Modules.Notifications.App.Consumers
{
    public class UserCreatedEventConsumer : IConsumer<UserCreatedEvent>
    {
        public UserCreatedEventConsumer()
        {
        }

        public Task Consume(ConsumeContext<UserCreatedEvent> context)
        {
            throw new NotImplementedException();
        }
    }
}
