using Microsoft.EntityFrameworkCore;
using ProjectSharp.Gui.Database.Entities.Users;

namespace ProjectSharp.Gui.Database;

public class PSharpContext : DbContext
{
    private const string ConnectionString =
        "server=172.17.0.2;port=3306;database=ProjectSharp;user=root;password=example";

    private readonly ServerVersion _serverVersion = ServerVersion.AutoDetect(ConnectionString);

    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseMySql(ConnectionString, _serverVersion);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasKey(e => e.Id);

        modelBuilder.Entity<User>()
            .Property(p => p.Email).IsRequired();
        modelBuilder.Entity<User>()
            .Property(p => p.Password).IsRequired();
        modelBuilder.Entity<User>()
            .Property(p => p.Role).IsRequired();

        modelBuilder
            .Entity<User>()
            .HasOne(e => e.CreatedBy)
            .WithMany()
            .OnDelete(DeleteBehavior.ClientSetNull); // To prevent cascade cycles on SQL Server

        modelBuilder
            .Entity<User>()
            .HasOne(e => e.UpdatedBy)
            .WithMany();

        modelBuilder.Entity<User>()
            .HasData(new
            {
                Id = Guid.NewGuid(), Email = "admin",
                Password = "$2a$11$wavn.EqSjRjLzfaE9jsN6uRLgU51Uu6o39kZUOQld11HwF9En7imy",
                Role = UserRole.Admin.ToString(), CreatedOn = DateTimeOffset.Now
            });
    }
}