using Microsoft.EntityFrameworkCore;
using ProjectSharp.DataAccess.Entities;

namespace ProjectSharp.DataAccess;

public class PSharpContext : DbContext
{
    public DbSet<User> Users { get; set; }
    
    private const string ConnectionString = "server=172.17.0.3;port=3306;database=ProjectSharp;user=root;password=example";

    readonly ServerVersion _serverVersion = ServerVersion.AutoDetect(ConnectionString);
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseMySql(ConnectionString, _serverVersion);
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<User>()
        //     .HasKey(e => e.Id);
    }
}