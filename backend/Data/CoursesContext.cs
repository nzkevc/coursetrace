using Microsoft.EntityFrameworkCore;
using Models;

public class CoursesContext : DbContext
{
    public CoursesContext(DbContextOptions<CoursesContext> options) : base(options) { }
    public DbSet<Semester> Semesters { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Assignment> Assignments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Semester>()
            .HasMany(c => c.Courses)
            .WithMany(s => s.Semesters)
            .UsingEntity(j => j.ToTable("CourseSemester"));

        modelBuilder.Entity<Course>()
            .HasMany(c => c.Assignments)
            .WithOne(a => a.Course)
            .HasForeignKey(a => a.CourseId);

        CoursesSeedData.Seed(modelBuilder);
    }
}