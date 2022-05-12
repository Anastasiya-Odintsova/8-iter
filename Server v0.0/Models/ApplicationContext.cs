namespace Server_v0._0.Models
{
    using Microsoft.EntityFrameworkCore;
    public class ApplicationContext : DbContext
    {
        public DbSet<Route> Routes { get; set; }
        public DbSet<WorkDone> WorkDones { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Driver)
                .WithMany(b => b.Payments)
                .HasForeignKey(p => p.DriverId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<WorkDone>()
                .HasOne(p => p.Route)
                .WithMany(b => b.WorkDones)
                .HasForeignKey(p => p.RouteId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.WorkDone)
                .WithMany(b => b.Payments)
                .HasForeignKey(p => p.WorkDoneId)
                .OnDelete(DeleteBehavior.Cascade);
        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}