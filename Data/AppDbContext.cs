using CourseManager.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseManager.Data;
public class AppDbContext : DbContext
{

    public DbSet<Course> Courses { get; set; }
    public DbSet<User> Users { get; set; }

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
            x.ToTable("Course");
            x.HasKey(x => x.Id);
            x.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn().HasColumnName("Id");
            x.Property(x => x.Title).HasColumnType("VARCHAR").HasMaxLength(160).HasColumnName("Title");
            x.Property(x => x.Status).HasConversion<string>().HasColumnName("Status");
            x.Property(x => x.Duration).HasColumnType("SMALLDATETIME").HasColumnName("Duration");
        });

        modelBuilder.Entity<User>(x =>
        {
            x.ToTable("User");
            x.HasKey(x => x.Id);
            x.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn().HasColumnName("Id");
            x.Property(x => x.Name).HasColumnType("VARCHAR").HasMaxLength(160).HasColumnName("Name");
            x.Property(x => x.Role).HasConversion<string>().HasColumnName("Role");
        });
    }
}