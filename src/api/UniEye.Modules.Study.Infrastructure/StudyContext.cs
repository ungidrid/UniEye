using Microsoft.EntityFrameworkCore;
using UniEye.Modules.Study.Core.Models;

namespace UniEye.Modules.Study.Infrastructure
{
    public class StudyContext: DbContext
    {
        public const string DEFAULT_SCHEMA = "study";

        public DbSet<Mark> Marks { get; set; }
        public DbSet<MarkType> MarkTypes { get; set; }

        public StudyContext(DbContextOptions<StudyContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var currentAssembly = typeof(StudyContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(currentAssembly);
        }
    }
}
