﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniEye.Modules.Students.Core.Models;

namespace UniEye.Modules.Students.Infrastructure.EntityConfigurations
{
    internal class StudyFormEntityConfiguration : IEntityTypeConfiguration<StudyForm>
    {
        public void Configure(EntityTypeBuilder<StudyForm> builder)
        {
            builder.ToTable(nameof(StudyForm), StudentsContext.DEFAULT_SCHEMA);

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