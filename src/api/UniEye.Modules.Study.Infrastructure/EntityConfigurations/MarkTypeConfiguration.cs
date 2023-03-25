using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniEye.Modules.Study.Core.Models;
using UniEye.Shared.Domain;

namespace UniEye.Modules.Study.Infrastructure.EntityConfigurations
{
    public class MarkTypeConfiguration : IEntityTypeConfiguration<MarkType>
    {
        public void Configure(EntityTypeBuilder<MarkType> builder)
        {
            builder.ToTable(nameof(MarkType), StudyContext.DEFAULT_SCHEMA);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasDefaultValue(1)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Code).IsRequired();
            builder.Property(x => x.Description).IsRequired();

            builder.HasData(Enumeration.GetAll<MarkType>());
        }
    }
}
