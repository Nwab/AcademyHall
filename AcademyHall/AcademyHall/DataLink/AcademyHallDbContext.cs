using AcademyHall.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AcademyHall.DataLink
{
    public class AcademyHallDbContext : IdentityDbContext<AcademyUser, AcademyRole, int, AcademyUserLogin, AcademyUserRole, AcademyUserClaim>
    {
        public AcademyHallDbContext()
            : base("DefaultConnection")
        {

        }

        public static AcademyHallDbContext Create()
        {
            return new AcademyHallDbContext();
        }

        public DbSet<StaffDetail> StaffDetails { get; set; }
        public DbSet<StudentDetail> StudentDetails { get; set; }
        public DbSet<ParentGuardian> ParentGuardians { get; set; }
        public DbSet<AssessmentType> AssessmentTypes { get; set; }
        public DbSet<ScoreRecord> ScoreRecords { get; set; }
        public DbSet<StudentGradeHistory> StudentGradeHistories { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectArea> SubjectAreas { get; set; }
        public DbSet<SubjectGrade> SubjectGrades { get; set; }
        public DbSet<TrimesterName> TrimesterNames { get; set; }
        public DbSet<TrimesterAssessmentBreakDown> TrimesterAssessmentBreakDowns { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<GradeLevel> GradeLevels { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<ParentGuardianStudent> ParentGuardianStudents { get; set; }
        public DbSet<AuditRecord> AuditRecords { get; set; }
        public DbSet<AuditRecordField> AuditRecordFields { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<LGA> LGAs { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Setting> Settings { get; set; }
        


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Entity<UserProfile>().MapToStoredProcedures();
            //modelBuilder.Entity<IoTUsers>().MapToStoredProcedures();
            modelBuilder.Entity<AcademyRole>().ToTable("AcademyRole");
            modelBuilder.Entity<AcademyUserRole>().ToTable("AcademyUserRole");
            modelBuilder.Entity<AcademyUserClaim>().ToTable("AcademyUserClaim");
            modelBuilder.Entity<AcademyUserLogin>().ToTable("AcademyUserLogin");
            modelBuilder.Entity<AcademyUser>().ToTable("AcademyUserProfile");

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        public object GetPrimaryKeyValue(DbEntityEntry entry)
        {
            var objectStateEntry = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity);
            return objectStateEntry.EntityKey.EntityKeyValues[0].Value;
        }
    }
    }
