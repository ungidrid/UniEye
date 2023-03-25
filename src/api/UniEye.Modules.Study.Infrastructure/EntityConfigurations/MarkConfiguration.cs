using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniEye.Modules.Study.Core.Models;

namespace UniEye.Modules.Study.Infrastructure.EntityConfigurations
{
    public class MarkConfiguration : IEntityTypeConfiguration<Mark>
    {
        public void Configure(EntityTypeBuilder<Mark> builder)
        {
            builder.ToTable(nameof(Mark), StudyContext.DEFAULT_SCHEMA);

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.MarkType)
                .WithMany()
                .HasForeignKey(x => x.MarkTypeId);

            builder.HasIndex(x => new { x.StudentId, x.SubjectId })
                .HasDatabaseName("IX_Mark_StudentId_SubjectId");
        }
    }
}
