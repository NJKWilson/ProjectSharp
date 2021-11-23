using Microsoft.EntityFrameworkCore;
using ProjectSharp.Gui.Database.Entities;
using ProjectSharp.Gui.Database.Entities.Users;
using ProjectSharp.Gui.Database.Enums;

namespace ProjectSharp.Gui.Database;

public class PSharpContext : DbContext
{
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public DbSet<User> Users { get; set; }
    
    private const string ConnectionString = "server=172.17.0.2;port=3306;database=ProjectSharp;user=root;password=example";

    readonly ServerVersion _serverVersion = ServerVersion.AutoDetect(ConnectionString);
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseMySql(ConnectionString, _serverVersion);
    
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


        var seedUser = new User
        {
            Email = "admin",
            Password = "",
            Role = UserRole.Admin.ToString(),
            CreatedOn = DateTime.Now,
        };
        
        modelBuilder.Entity<User>()
            .HasData(new {Id = Guid.NewGuid() ,Email = "admin", Password = "", Role = UserRole.Admin.ToString(), CreatedOn = DateTimeOffset.Now});
    }
}