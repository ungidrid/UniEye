
using Microsoft.EntityFrameworkCore;
using UniEye.Modules.Students.Core.Models;

namespace UniEye.Modules.Students.Infrastructure
{
    public class StudentsContext: DbContext
    {
        public const string DEFAULT_SCHEMA = "students";

        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<PaymentTerm> PayemntTerms { get; set; }
        public DbSet<StudyForm> StudyForms { get; set; }

        public StudentsContext(DbContextOptions<StudentsContext> options): base(options) { }
    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            var currentAssembly = typeof(StudentsContext).Assembly;
            builder.ApplyConfigurationsFromAssembly(currentAssembly);
            builder.Seed();
        }
    }
}
