using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models.Entities;

namespace StudentManagementSystem.Models.Data;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
    {
    }

    public DbSet<StudentEntity> Students { get; set; }
    public DbSet<CourseEntity> Courses { get; set; }
    public DbSet<StudentCourseEntity> studentCourses { get; set; }
    public DbSet<GradeEntity> grades { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<StudentCourseEntity>()
            .HasIndex(sc => new { sc.StudentId, sc.CourseId })
            .IsUnique();
        modelBuilder.Entity<CourseEntity>()
            .HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<StudentCourseEntity>()
            .HasQueryFilter(x=>!x.IsDeleted);
        modelBuilder.Entity<StudentEntity>()
            .HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<GradeEntity>()
            .HasQueryFilter(x => !x.IsDeleted);
    }
}
