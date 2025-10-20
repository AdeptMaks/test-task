using Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<BaseUser> Users { get; set; }
    public DbSet<URLEntity> URLs { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<BaseUser>()
            .HasDiscriminator<string>("Discriminator")
            .HasValue<UserEntity>("User")
            .HasValue<AdminEntity>("Admin");

        modelBuilder.Entity<UserEntity>();
        modelBuilder.Entity<AdminEntity>();
        
        modelBuilder.Entity<URLEntity>()
            .HasOne(u => u.User)
            .WithMany()
            .HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
