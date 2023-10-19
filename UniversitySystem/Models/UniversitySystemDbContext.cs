using Microsoft.EntityFrameworkCore;
using UniversitySystem.Models.DTOs;

namespace UniversitySystem.Models
{
    public partial class UniversitySystemDbContext : DbContext
    {


        public UniversitySystemDbContext(DbContextOptions<UniversitySystemDbContext> options) : base(options)  {   }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentLectureDTO>().HasNoKey();
            modelBuilder.Entity<MealDishes>().HasNoKey();
        }
        public DbSet<Announcement> Announcements { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Faculty> Faculties { get; set; } = null!;
        public DbSet<Lecture> Lectures { get; set; } = null!;
        public DbSet<LectureDetail> LectureDetails { get; set; } = null!;
        public DbSet<Semester> Semesters { get; set; } = null!;
        public DbSet<Status> Statuses { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<StudentInfoDTO> StudentInfo{ get; set; } = null!;
        public DbSet<StudentCertificationDTO> StudentCertification{ get; set; } = null!;
        public DbSet<StudentCourse> StudentCourses { get; set; } = null!;
        public DbSet<StudentLecture> StudentLectures { get; set; } = null!;
        public DbSet<StudentLectureDTO> StudentLectureView { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<UserIban> UserIbans { get; set; } = null!;
        public DbSet<UserImage> UserImages { get; set; } = null!;
        public DbSet<Notification>? Notifications { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Dish> Dishes{ get; set; }
        public DbSet<MealDishes> MealDishes { get; set; }
        public DbSet<Faq> FAQ { get; set; } = null!;
    }
}
