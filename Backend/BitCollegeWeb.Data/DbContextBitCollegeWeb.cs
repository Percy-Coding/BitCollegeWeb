using BitCollegeWeb.Infrastructure.Mapping;
using BitCollegeWeb.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Infrastructure
{
    public class DbContextBitCollegeWeb : DbContext
    {
        public DbContextBitCollegeWeb(DbContextOptions<DbContextBitCollegeWeb> options) : base(options)
        {
        }

        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<CalificationAssignment> CalificationAssignments { get; set; }
        public DbSet<CalificationExam> CalificationExams { get; set; }
        public DbSet<CalificationSystem> CalificationSystems { get; set; }
        public DbSet<CalificationSystemTypeCalification> CalificationSystemTypes { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Classroom>  Classrooms { get; set; }
        public DbSet<ClassroomExternalTool> ClassroomExternalTools { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Evidence> Evidences  { get; set; }
        public DbSet<Exam>  Exams { get; set; }
        public DbSet<ExternalTool> ExternalTools  { get; set; }
        public DbSet<GeneralInformation>  GeneralInformations { get; set; }
        public DbSet<Inscription> Inscriptions { get; set; }
        public DbSet<Institution> Institutions  { get; set; }
        public DbSet<Notification>  Notifications { get; set; }
        public DbSet<ProgrammingStudy> ProgrammingStudies  { get; set; }
        public DbSet<Registration> Registrations  { get; set; }
        public DbSet<Schedule> Schedules  { get; set; }
        public DbSet<ScheduleDay> ScheduleDays  { get; set; }
        public DbSet<Section> Sections  { get; set; }
        public DbSet<SectionTypeSection> SectionTypes { get; set; }
        public DbSet<Student> Students  { get; set; }
        public DbSet<StudentExperience> StudentExperiences { get; set; }
        public DbSet<StudentSection> StudentSections  { get; set; }
        public DbSet<Teacher> Teachers  { get; set; }
        public DbSet<TeacherExperience> TeacherExperiences { get; set; }
        public DbSet<TeacherForum>  TeacherForums { get; set; }
        public DbSet<TeacherSection> TeacherSections  { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<TypeCalification> TypeCalifications  { get; set; }
        public DbSet<TypeProgrammingClass> TypeProgrammingClasses { get; set; }
        public DbSet<TypeSection> TypeSections { get; set; }
        public DbSet<TypeStudy> TypeStudies  { get; set; }
        public DbSet<URL> Urls  { get; set; }

        //patron de diseño Builder aplicado en cada entidad mediante los mappings
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AnnouncementMap());
            modelBuilder.ApplyConfiguration(new AssignmentMap());
            modelBuilder.ApplyConfiguration(new CalificationAssignmentMap());
            modelBuilder.ApplyConfiguration(new CalificationExamMap());
            modelBuilder.ApplyConfiguration(new CalificationSystemMap());
            modelBuilder.ApplyConfiguration(new CalificationSystemTypeCalificationMap());
            modelBuilder.ApplyConfiguration(new ChatMap());
            modelBuilder.ApplyConfiguration(new ClassroomExternalToolMap());
            modelBuilder.ApplyConfiguration(new ClassroomMap());
            modelBuilder.ApplyConfiguration(new CompanyMap());
            modelBuilder.ApplyConfiguration(new DayMap());
            modelBuilder.ApplyConfiguration(new EvidenceMap());
            modelBuilder.ApplyConfiguration(new ExamMap());
            modelBuilder.ApplyConfiguration(new ExternalToolMap());
            modelBuilder.ApplyConfiguration(new GeneralInformationMap());
            modelBuilder.ApplyConfiguration(new InscriptionMap());
            modelBuilder.ApplyConfiguration(new InstitutionMap());
            modelBuilder.ApplyConfiguration(new NotificationMap());
            modelBuilder.ApplyConfiguration(new ProgrammingStudyMap());
            modelBuilder.ApplyConfiguration(new RegistrationMap());
            modelBuilder.ApplyConfiguration(new ScheduleDayMap());
            modelBuilder.ApplyConfiguration(new ScheduleMap());
            modelBuilder.ApplyConfiguration(new SectionMap());
            modelBuilder.ApplyConfiguration(new SectionTypeSectionMap());
            modelBuilder.ApplyConfiguration(new StudentExperienceMap());
            modelBuilder.ApplyConfiguration(new StudentMap());
            modelBuilder.ApplyConfiguration(new StudentSectionMap());
            modelBuilder.ApplyConfiguration(new TeacherExperienceMap());
            modelBuilder.ApplyConfiguration(new TeacherForumMap());
            modelBuilder.ApplyConfiguration(new TeacherMap());
            modelBuilder.ApplyConfiguration(new TeacherSectionMap());
            modelBuilder.ApplyConfiguration(new TopicMap());
            modelBuilder.ApplyConfiguration(new TypeCalificationMap());
            modelBuilder.ApplyConfiguration(new TypeProgrammingClassMap());
            modelBuilder.ApplyConfiguration(new TypeSectionMap());
            modelBuilder.ApplyConfiguration(new TypeStudyMap());
            modelBuilder.ApplyConfiguration(new URLMap());
        }
    }
}
