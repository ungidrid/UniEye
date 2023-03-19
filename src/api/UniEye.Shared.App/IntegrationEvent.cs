using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UniEye.Shared.App
{
    public record IntegrationEvent : CorrelatedBy<Guid>
    {
        [JsonConstructor]
        public IntegrationEvent(Guid? correlationId = null, DateTime? creationDate = null)
        {
            CorrelationId = correlationId ?? Guid.NewGuid();
            CreationDate = creationDate ?? DateTime.UtcNow;
        }

        [JsonInclude]
        public Guid CorrelationId { get; protected init; }

        [JsonInclude]
        public DateTime CreationDate { get; private init; }
    }

}
