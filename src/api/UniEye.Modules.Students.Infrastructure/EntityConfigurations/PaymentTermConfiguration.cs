using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniEye.Modules.Students.Core.Models;

namespace UniEye.Modules.Students.Infrastructure.EntityConfigurations
{
    internal class PaymentTermConfiguration : IEntityTypeConfiguration<PaymentTerm>
    {
        public void Configure(EntityTypeBuilder<PaymentTerm> builder)
        {
            builder.ToTable(nameof(PaymentTerm), StudentsContext.DEFAULT_SCHEMA);

            builder.HasKey(t => t.Id);

            builder.Property(x => x.Id)
                .HasDefaultValue(1)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Code).IsRequired();
        }
    }
}
