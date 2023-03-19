using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UniEye.Shared.App;

namespace UniEye.Modules.Notifications.Shared.Commands
{
    public record SendNotificationIntegrationCommand: IntegrationEvent
    {
        public SendNotificationIntegrationCommand(string templateCode, Dictionary<string, string> parameters, Guid? correlationId = null, DateTime? creationDate = null): 
            base(correlationId, creationDate)
        {
            TemplateCode = templateCode;
            Parameters = parameters;
        }

        [JsonConstructor]
        public SendNotificationIntegrationCommand(string templateCode, Dictionary<string, string> parameters, Guid correlationId, DateTime creationDate):
            this(templateCode, parameters, (Guid?)correlationId, creationDate)
        {
        }

        public string TemplateCode { get; private set; }
        public Dictionary<string, string> Parameters { get; private set; }
    }
}
