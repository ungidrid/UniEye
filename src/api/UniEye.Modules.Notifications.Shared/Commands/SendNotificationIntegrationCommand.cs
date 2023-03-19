using System.Text.Json.Serialization;
using UniEye.Modules.Notifications.Shared.Templates;
using UniEye.Shared.App;

namespace UniEye.Modules.Notifications.Shared.Commands
{
    public record SendNotificationIntegrationCommand: IntegrationEvent
    {
        public NotificationTemplate Template { get; set; }
        public Guid Identity { get; set; }

        public SendNotificationIntegrationCommand()
        {
        }

        public SendNotificationIntegrationCommand(NotificationTemplate template, Guid identity, Guid? correlationId = null, DateTime? creationDate = null): 
            base(correlationId, creationDate)
        {
            Template = template;
            Identity = identity;
        }
    }
}
