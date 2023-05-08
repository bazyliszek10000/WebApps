using Microsoft.EntityFrameworkCore;

namespace MbDB.Entities;

public class MbDbContext : DbContext
{
    private const string connectionString = "Server=localhost;Database=MbDataBase;Trusted_Connection=True;TrustServerCertificate=True";
    
    public DbSet<Candidate> Candidates { get; set; }
    
    public DbSet<Voter> Voters { get; set; }
    
    public DbSet<Order> Orders { get; set; }
    
    public DbSet<OrderLine> OrderLines { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .Property(x => x.CreateDate)
            .IsRequired();

        modelBuilder.Entity<Order>()
            .Property(x => x.Status)
            .IsRequired();

        modelBuilder.Entity<Order>()
            .Property(x => x.ClientName)
            .IsRequired();

        modelBuilder.Entity<Order>()
            .Property(x => x.OrderPrice)
            .IsRequired();
        
        modelBuilder.Entity<OrderLine>()
            .Property(x => x.Product)
            .IsRequired();
        
        modelBuilder.Entity<OrderLine>()
            .Property(x => x.Price)
            .IsRequired();
        
        modelBuilder.Entity<OrderLine>()
            .HasMany<Order>(s => s.Orders)
            .WithMany(c => c.OrderLines)
            .UsingEntity(j => j.ToTable("OrdersOrderLines"));
        
        modelBuilder.Entity<Candidate>()
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(255);
        
        modelBuilder.Entity<Voter>()
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(255);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }
}