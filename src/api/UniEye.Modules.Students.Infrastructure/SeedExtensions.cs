using Microsoft.EntityFrameworkCore;
using UniEye.Modules.Students.Core.Models;

namespace UniEye.Modules.Students.Infrastructure
{
    internal static class SeedExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<StudyForm>().HasData(
                StudyForm.FullTime,
                StudyForm.External
            );

            builder.Entity<Group>().HasData(
                new Group() { Id = 1, Name = "ПМІ-11", StudyFormId = StudyForm.FullTime },
                new Group() { Id = 2, Name = "ПМІ-12", StudyFormId = StudyForm.FullTime },
                new Group() { Id = 3, Name = "ПМІ-13", StudyFormId = StudyForm.FullTime },
                new Group() { Id = 4, Name = "ПМІ-14", StudyFormId = StudyForm.FullTime }
            );
        }
    }
}
