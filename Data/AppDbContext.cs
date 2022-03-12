using CourseManager.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseManager.Data;
public class AppDbContext : DbContext
{

    public DbSet<Course> Courses { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }


    // protected override void OnConfiguring(DbContextOptionsBuilder options)
    //        => options.UseSqlServer("Data source=(localdb)\\mssqllocaldb;Initial Catalog=CursoEFCore;Integrated Security=true");

    // protected override void OnConfiguring(DbContextOptionsBuilder options)
    //     => options.UseSqlServer("Server=localhost,1433;Database=CourseManager;User ID=sa;Password=1q2w3e4r@#$");

    protected override void OnConfiguring(DbContextOptionsBuilder options)
                => options.UseSqlite("DataSource=app.db;Cache=Shared");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(x =>
        {
            x.Property(x => x.Duration).HasColumnType("SMALLDATETIME");
            x.Property(x => x.Status).HasColumnType("INTEGER");
        });

        modelBuilder.Entity<Role>(x =>
        {
            
        });


    }
}