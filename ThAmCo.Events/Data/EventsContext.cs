using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;
using ThAmCo.Events.DTOs;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using ThAmCo.Events.FoodItems;

namespace ThAmCo.Events.Data
{
    public class EventsContext : DbContext
    {
        public string DbPath { get; set; } = string.Empty;

        public DbSet<Guest> Guests { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Staffing> Staffing { get; set; }

        public DbSet<GuestBooking> GuestBookings { get; set; }

        public DbSet<Staff> Staff { get; set; }

        private IWebHostEnvironment HostEnv { get; }

        public EventsContext(DbContextOptions<EventsContext> options, IWebHostEnvironment env) : base(options)
        {
            HostEnv = env;
            var folder = Environment.SpecialFolder.MyDocuments;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "Events.db");
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Composite key
            builder.Entity<GuestBooking>()
            .HasKey(g => new { g.GuestId, g.EventId });


            //Handle the many to many guest-event
            builder.Entity<Guest>()
            .HasMany(gb => gb.Bookings)
            .WithOne(gb => gb.Guest)
            .HasForeignKey(gb => gb.GuestId);

            //Handle the many to many
            builder.Entity<Event>()
            .HasMany(gb => gb.Bookings)
            .WithOne(gb => gb.Event)
            .HasForeignKey(gb => gb.EventId);

            builder.Entity<Staff>()
                .HasMany(ev => ev.Events);

            builder.Entity<Staffing>()
                .HasKey(st => new { st.StaffId, st.EventId });

            //Handle the many to many Staff - Event
            builder.Entity<Staff>()
                .HasMany(ev => ev.Events)
                .WithOne(ev => ev.Staff)
                .HasForeignKey(ev => ev.StaffId);

            //Handle the many to many
            builder.Entity<Event>()
                .HasMany(ev => ev.StaffBooking)
                .WithOne(ev => ev.Event)
                .HasForeignKey(ev => ev.EventId);
            
            builder.Entity<Event>()
                .Property(e => e.EventTypeId)
                .IsFixedLength();


            //Seeding guest data
            builder.Entity<Guest>().HasData(
                new Guest { Id = 1, Forename = "John", Surname = "Smith", Payment= 0123456, EmailAddress = "JSmith@outlook.com", Deleted = false },
                new Guest { Id = 2, Forename = "Jim", Surname = "Phillips", Payment = 1234567, EmailAddress = "JPhillips@hotmail.com", Deleted = false },
                new Guest { Id = 3, Forename = "Sally", Surname = "Simpson", Payment = 2345678, EmailAddress = "SillySally@googlemail.com", Deleted = false },
                new Guest { Id = 4, Forename = "Mike", Surname = "Trouble", Payment = 654321, EmailAddress = "MTrouble@protonmail.com", Deleted = true }

                );


            builder.Entity<Event>().HasData(
                new Event {  Id = 1, Title = "John Smith's Wedding", Duration = new TimeSpan(9, 0, 0
                ), Date = new DateTime(2022, 12, 12), EventTypeId = "WED" },
                new Event { Id = 2, Title = "Jim Phillips' Golf Club Bash", Duration = new TimeSpan(hours: 3, minutes: 0, seconds: 0
                ), Date = new DateTime(2022, 12, 13),EventTypeId = "PTY" },
                new Event { Id = 3, Title = "Silly Sally's Hen Party", Duration = new TimeSpan(6,0,0
               ), Date = new DateTime(2023, 12, 20), EventTypeId = "PTY"},
                new Event { Id = 4, Title = "Mike Trouble's Prison Release Party", Duration = new TimeSpan(3, 30, 0
                ), Date = new DateTime(2022, 12, 25), EventTypeId = "CON" }


                );

            builder.Entity<GuestBooking>().HasData(
                new GuestBooking { GuestId = 1, EventId = 1, Attended = true },
                new GuestBooking { GuestId = 2, EventId = 2, Attended = true },
                new GuestBooking { GuestId = 3, EventId = 3, Attended = false },
                new GuestBooking { GuestId = 4, EventId = 4, Attended = false }

                );


            builder.Entity<Staff>().HasData(
                new Staff { Id = 1, Name = "Florence Nightingale", Email = "FNightingale@Gmail.com", Role = "Security", FirstAidQulaified = false },
                new Staff { Id = 2, Name = "Ted Bundy", Email = "TTTed@hotmail.com", Role = "Bar Staff", FirstAidQulaified = true },
                new Staff { Id = 3, Name = "Bruce Lee", Email = "BLee@email.com", Role = "Waiter", FirstAidQulaified = false },
                new Staff { Id = 4, Name = "Joe Bloggs", Email = "JBloggs@msn.com", Role = "Waiter", FirstAidQulaified = true }



                );

            builder.Entity<Staffing>().HasData(
                new Staffing { StaffId = 1, EventId = 1 },
                new Staffing { StaffId = 2, EventId = 2 },
                new Staffing { StaffId = 3, EventId = 3 },
                new Staffing { StaffId = 3, EventId = 1 },
                new Staffing { StaffId = 1, EventId = 4 }

                );

        }

        public DbSet<ThAmCo.Events.DTOs.EventDTO> EventDTO { get; set; }

        public DbSet<ThAmCo.Events.FoodItems.FoodItem> FoodItem { get; set; }
    }  
}
