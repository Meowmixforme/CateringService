using Microsoft.EntityFrameworkCore;

namespace ThAmCo.Catering.Data
{
    public class CateringContext : DbContext
    {
        // Used to set the database path manually (not recommended for ASP.NET Core DI)
        public CateringContext()
        {
            var folder = Environment.SpecialFolder.MyDocuments;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "Catering.db");
        }

        // This constructor is required for dependency injection
        public CateringContext(DbContextOptions<CateringContext> options)
            : base(options)
        {
            var folder = Environment.SpecialFolder.MyDocuments;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "Catering.db");
        }

        public string DbPath { get; set; } = string.Empty;

        public DbSet<Menu> Menus { get; set; }
        public DbSet<FoodBooking> FoodBookings { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<MenuFoodItem> MenuFoodItems { get; set; }

        // Remove OnConfiguring if you use DI (recommended).
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Only configure if not already configured (for fallback/local usage)
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"Data Source={DbPath}");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Set up FoodBooking -> Menu one-to-many relationship
            builder.Entity<FoodBooking>()
                .HasOne(f => f.Menu)
                .WithMany(f => f.FoodBookings)
                .HasForeignKey(f => f.MenuId);

            // Composite key for MenuFoodItem (many-to-many)
            builder.Entity<MenuFoodItem>()
                .HasKey(mf => new { mf.FoodItemId, mf.MenuId });

            // Many-to-many relationships
            builder.Entity<MenuFoodItem>()
                .HasOne(mf => mf.Menu)
                .WithMany(mf => mf.FoodItems)
                .HasForeignKey(mf => mf.MenuId);

            builder.Entity<MenuFoodItem>()
                .HasOne(mf => mf.FoodItem)
                .WithMany(mf => mf.Menus)
                .HasForeignKey(mf => mf.FoodItemId);

            // Seed data
            builder.Entity<FoodItem>().HasData(
                new FoodItem { FoodItemId = 1, Description = "Delicious Chocolate", UnitPrice = 3.50f },
                new FoodItem { FoodItemId = 2, Description = "Steaming Steak", UnitPrice = 5.00f },
                new FoodItem { FoodItemId = 3, Description = "Juicy Burger", UnitPrice = 3.50f },
                new FoodItem { FoodItemId = 4, Description = "Mouth watering Fries", UnitPrice = 2.50f },
                new FoodItem { FoodItemId = 5, Description = "Fizzy Soda", UnitPrice = 3.00f },
                new FoodItem { FoodItemId = 6, Description = "Hot Tea", UnitPrice = 2.50f },
                new FoodItem { FoodItemId = 7, Description = "Warm Coffee", UnitPrice = 2.50f }
            );

            builder.Entity<Menu>().HasData(
                new Menu { MenuId = 1, MenuName = "Breakfast" },
                new Menu { MenuId = 2, MenuName = "Steak & Chips" },
                new Menu { MenuId = 3, MenuName = "Burger & Fries" },
                new Menu { MenuId = 4, MenuName = "Steak" },
                new Menu { MenuId = 5, MenuName = "Burger" },
                new Menu { MenuId = 6, MenuName = "Fries" },
                new Menu { MenuId = 7, MenuName = "Burger & Tea" }
            );

            builder.Entity<MenuFoodItem>().HasData(
                new MenuFoodItem { MenuId = 1, FoodItemId = 1 },
                new MenuFoodItem { MenuId = 2, FoodItemId = 2 },
                new MenuFoodItem { MenuId = 3, FoodItemId = 3 },
                new MenuFoodItem { MenuId = 4, FoodItemId = 4 }
            );

            builder.Entity<FoodBooking>().HasData(
                new FoodBooking { FoodBookingId = 1, ClientReferenceId = 1, NumberOfGuests = 2, MenuId = 1 },
                new FoodBooking { FoodBookingId = 2, ClientReferenceId = 2, NumberOfGuests = 4, MenuId = 2 },
                new FoodBooking { FoodBookingId = 3, ClientReferenceId = 3, NumberOfGuests = 3, MenuId = 6 }
            );
        }
    }
}