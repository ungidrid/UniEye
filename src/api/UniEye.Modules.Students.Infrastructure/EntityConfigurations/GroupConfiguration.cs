using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniEye.Modules.Students.Core.Models;

namespace UniEye.Modules.Students.Infrastructure.EntityConfigurations
{
    internal class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable(nameof(Group), StudentsContext.DEFAULT_SCHEMA);

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.StudyForm)
                .WithMany()
                .HasForeignKey(x => x.StudyFormId);
        }
    }
}
