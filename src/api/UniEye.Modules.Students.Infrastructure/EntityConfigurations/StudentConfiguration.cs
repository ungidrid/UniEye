﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniEye.Modules.Students.Core.Models;

namespace UniEye.Modules.Students.Infrastructure.EntityConfigurations
{
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable(nameof(Student), StudentsContext.DEFAULT_SCHEMA);

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Group)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.GroupId);

            builder.HasOne(x => x.PaymentTerm)
                .WithMany()
                .HasForeignKey(x => x.PaymentTermId);

            builder.OwnsOne(x => x.Name);
        }
    }
}
