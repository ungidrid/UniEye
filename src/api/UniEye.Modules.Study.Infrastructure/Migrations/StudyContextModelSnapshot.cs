﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniEye.Modules.Study.Infrastructure;

#nullable disable

namespace UniEye.Modules.Study.Infrastructure.Migrations
{
    [DbContext(typeof(StudyContext))]
    partial class StudyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UniEye.Modules.Study.Core.Models.Mark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("MarkTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MarkTypeId");

                    b.HasIndex("StudentId", "SubjectId")
                        .HasDatabaseName("IX_Mark_StudentId_SubjectId");

                    b.ToTable("Mark", "study");
                });

            modelBuilder.Entity("UniEye.Modules.Study.Core.Models.MarkType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MarkType", "study");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "LECTURE",
                            Description = "Контроль на лекції",
                            Name = "Лекція"
                        },
                        new
                        {
                            Id = 2,
                            Code = "SEMINAR",
                            Description = "Практичне/семінарське заняття",
                            Name = "Практична"
                        },
                        new
                        {
                            Id = 3,
                            Code = "LAB",
                            Description = "Лабораторна робота",
                            Name = "Лабораторна"
                        },
                        new
                        {
                            Id = 4,
                            Code = "INDIVIDUAL",
                            Description = "Самостійна робота",
                            Name = "Самостійна"
                        },
                        new
                        {
                            Id = 5,
                            Code = "PRESENTATION",
                            Description = "Доповідь",
                            Name = "Доповідь"
                        },
                        new
                        {
                            Id = 6,
                            Code = "RETAKE",
                            Description = "Перездача",
                            Name = "Перездача"
                        },
                        new
                        {
                            Id = 7,
                            Code = "MODULE",
                            Description = "Модульна робота",
                            Name = "Модуль"
                        },
                        new
                        {
                            Id = 8,
                            Code = "CONTROL",
                            Description = "Контрольна робота",
                            Name = "Контрольна"
                        },
                        new
                        {
                            Id = 9,
                            Code = "TEST",
                            Description = "Тест",
                            Name = "Тест"
                        },
                        new
                        {
                            Id = 10,
                            Code = "COLLOQUIUM",
                            Description = "Колоквіум",
                            Name = "Колоквіум"
                        },
                        new
                        {
                            Id = 11,
                            Code = "EXAM",
                            Description = "Екзамен",
                            Name = "Екзамен"
                        },
                        new
                        {
                            Id = 12,
                            Code = "ZALIK",
                            Description = "Залік",
                            Name = "Залік"
                        },
                        new
                        {
                            Id = 13,
                            Code = "OTHER",
                            Description = "Інше",
                            Name = "Інше"
                        });
                });

            modelBuilder.Entity("UniEye.Modules.Study.Core.Models.Mark", b =>
                {
                    b.HasOne("UniEye.Modules.Study.Core.Models.MarkType", "MarkType")
                        .WithMany()
                        .HasForeignKey("MarkTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MarkType");
                });
#pragma warning restore 612, 618
        }
    }
}
