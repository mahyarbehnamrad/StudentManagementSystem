using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models.Entities;

namespace StudentManagementSystem.Models.Data;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<StudentCourse> studentCourses { get; set; }
    public DbSet<Grades> grades { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<StudentCourse>()
            .HasIndex(sc => new { sc.StudentId, sc.CourseId })
            .IsUnique();
        modelBuilder.Entity<Course>()
            .HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<StudentCourse>()
            .HasQueryFilter(x=>!x.IsDeleted);
        modelBuilder.Entity<Student>()
            .HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<Grades>()
            .HasQueryFilter(x => !x.IsDeleted);
    }
}
