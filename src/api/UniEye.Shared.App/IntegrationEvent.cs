using MassTransit;
using System.Text.Json.Serialization;

namespace UniEye.Shared.App
{
    public record IntegrationEvent : CorrelatedBy<Guid>
    {
        public Guid CorrelationId { get; set; }

        public DateTime CreationDate { get; set; }

        public IntegrationEvent()
        {
            CorrelationId = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }

        public IntegrationEvent(Guid? correlationId = null, DateTime? creationDate = null)
        {
            CorrelationId = correlationId ?? Guid.NewGuid();
            CreationDate = creationDate ?? DateTime.UtcNow;
        }
    }

}
