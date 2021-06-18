using BitCollegeWeb.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Data
{
    public class DbContextBitCollegeWeb : DbContext
    {
        public DbContextBitCollegeWeb(DbContextOptions<DbContextBitCollegeWeb> options) : base(options)
        {
        }

        public DbSet<Announcement> announcements { get; set; }
        public DbSet<Assignment> assignments { get; set; }
        public DbSet<CalificationAssignment> calificationAssignments { get; set; }
        public DbSet<CalificationExam> calificationExams { get; set; }
        public DbSet<CalificationSystem> calificationSystems { get; set; }
        public DbSet<CalificationSystemTypeCalification> calificationSystemTypes { get; set; }
        public DbSet<Chat> chats { get; set; }
        public DbSet<Classroom>  classrooms { get; set; }
        public DbSet<ClassroomExternalTool> ClassroomExternalTools { get; set; }
        public DbSet<Company> companies { get; set; }
        public DbSet<Day> days { get; set; }
        public DbSet<Evidence> evidences  { get; set; }
        public DbSet<Exam>  exams { get; set; }
        public DbSet<ExternalTool> externalTools  { get; set; }
        public DbSet<GeneralInformation>  generalInformation { get; set; }
        public DbSet<Inscription> inscriptions { get; set; }
        public DbSet<Institution> institutions  { get; set; }
        public DbSet<Notification>  notifications { get; set; }
        public DbSet<ProgrammingStudy> programmingStudies  { get; set; }
        public DbSet<Registration> registrations  { get; set; }
        public DbSet<Schedule> schedules  { get; set; }
        public DbSet<ScheduleDay> scheduleDays  { get; set; }
        public DbSet<Section> sections  { get; set; }
        public DbSet<SectionTypeSection> sectionTypes { get; set; }
        public DbSet<Student> students  { get; set; }
        public DbSet<StudentExperience> studentExperiences { get; set; }
        public DbSet<StudentSection> studentSections  { get; set; }
        public DbSet<Teacher> teachers  { get; set; }
        public DbSet<TeacherExperience> teacherExperiences { get; set; }
        public DbSet<TeacherForum>  teacherForums { get; set; }
        public DbSet<TeacherSection> teacherSections  { get; set; }
        public DbSet<Topic> topics { get; set; }
        public DbSet<TypeCalification> typeCalifications  { get; set; }
        public DbSet<TypeStudy> typeStudies  { get; set; }
        public DbSet<URL> urls  { get; set; }
        public DbSet<User> users  { get; set; }
}
}
