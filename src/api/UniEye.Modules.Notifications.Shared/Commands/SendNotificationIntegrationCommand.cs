using System.Text.Json.Serialization;
using UniEye.Modules.Notifications.Shared.Templates;
using UniEye.Shared.App;

namespace UniEye.Modules.Notifications.Shared.Commands
{
    public record SendNotificationIntegrationCommand: IntegrationEvent
    {
        public NotificationTemplate Template { get; }

        public SendNotificationIntegrationCommand(NotificationTemplate template, Guid? correlationId = null, DateTime? creationDate = null): 
            base(correlationId, creationDate)
        {
            Template = template;
        }

        [JsonConstructor]
        public SendNotificationIntegrationCommand(NotificationTemplate template, Guid correlationId, DateTime creationDate):
            this(template, (Guid?)correlationId, creationDate)
        {
        }
    }
}
