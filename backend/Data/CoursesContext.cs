using Microsoft.EntityFrameworkCore;
using Models;

public class CoursesContext : DbContext
{
    public CoursesContext(DbContextOptions<CoursesContext> options) : base(options) { }
    public DbSet<Semester> Semesters { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Assignment> Assignments { get; set; }
}