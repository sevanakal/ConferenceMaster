using Microsoft.EntityFrameworkCore;
using ConferenceMaster.Domain.Entities;

namespace ConferenceMaster.Persistence.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<EventSeat> EventSeats { get; set; }
    public DbSet<Seat> PhysicalSeats { get; set; }
    public DbSet<Hall> Halls { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Configure entity relationships and constraints here if needed



        var hallId = Guid.Parse("11111111-1111-1111-1111-111111111111");
        var seatId = Guid.Parse("22222222-2222-2222-2222-222222222222");
        var eventId = Guid.Parse("33333333-3333-3333-3333-333333333333");

        modelBuilder.Entity<Hall>().HasData(new Hall
        {
            Id = hallId,
            Name = "Mavi Salon",
            Capacity = 100
        });

        modelBuilder.Entity<Seat>().HasData(new Seat
        {
            Id = seatId,
            HallId = hallId,
            RowName = "A",
            Number = 1,
            CoordX = 10,
            CoordY = 20,
            ResponsibleUserId = null,
            DelegatedUserId = null
        });

        modelBuilder.Entity<Event>().HasData(new Event
        {
            Id = eventId,
            Name = "Tech Conference 2024",
            StartTime = DateTime.SpecifyKind(new DateTime(2026, 1, 1, 10, 0, 0), DateTimeKind.Utc),
            IsPaid = true,
            HallId = hallId
        });



    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Terminalden (Migration sırasında) gelen talepler için UTC hatasını engeller
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        base.OnConfiguring(optionsBuilder);
    }
}