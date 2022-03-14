using CourseManager.Entities;
using CourseManager.Enums;
using Microsoft.EntityFrameworkCore;

namespace CourseManager.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
    {
       
    }

    public DbSet<Course> Courses { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
                => options.UseSqlite("DataSource=app.db;Cache=Shared");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(x =>
        {
            x.ToTable("Courses");

            x.Property(x => x.Id).HasColumnType("INTEGER").ValueGeneratedOnAdd();

            x.HasKey(x => x.Id);

            x.Property(x => x.Title).HasColumnType("TEXT").IsRequired();

            x.Property(x => x.Duration).HasColumnType("TEXT").IsRequired();

            x.Property(x => x.Status).HasConversion(v =>
                 v.ToString(),
                 v => (EStatus)Enum.Parse(typeof(EStatus), v)
                )
                .IsRequired();
        });

        modelBuilder.Entity<Role>(x =>
        {
            x.ToTable("Roles");

            x.Property(x => x.Id).HasColumnType("INTEGER").ValueGeneratedOnAdd();

            x.HasKey(x => x.Id);

            x.Property(x => x.Name).HasColumnType("TEXT").IsRequired();

            x.Navigation(x=>x.Users);


        });

        modelBuilder.Entity<User>(x =>
        {
            x.ToTable("Users");

            x.Property(x => x.Id).HasColumnType("INTEGER").ValueGeneratedOnAdd();

            x.HasKey(x => x.Id);

            x.Property(x => x.Name).HasColumnType("TEXT").IsRequired();

            x.Property(x => x.RoleId).HasColumnType("INTEGER").IsRequired();

            x.HasIndex(x=>x.RoleId);

            x.HasOne(x=>x.Role)
                .WithMany(x=>x.Users)
                .HasForeignKey(x=>x.RoleId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

        });     


    }

}