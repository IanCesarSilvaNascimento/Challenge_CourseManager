using CourseManager.Entities;
using CourseManager.Enums;
using Microsoft.EntityFrameworkCore;

namespace CourseManager.Data;
public class AppDbContext : DbContext
{
    public DbSet<Course> Courses { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
                => options.UseSqlite("DataSource=app.db;Cache=Shared");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(x =>
        {
            x.Property(x => x.Status).HasConversion(v =>
                 v.ToString(),
                 v => (EStatus)Enum.Parse(typeof(EStatus), v)
            );
        });


    }
}