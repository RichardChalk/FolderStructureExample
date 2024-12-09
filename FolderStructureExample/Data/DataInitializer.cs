using FolderStructureExample.Models;

namespace FolderStructureExample.Data;

public static class DataInitializer
{
    public static void Seed(ApplicationDbContext dbContext)
    {
        // AddRange() så vi slipper anropar Add() flera ggr
        // Lägg till kunder
        var customer1 = new Customer { Id = Guid.NewGuid(), Name = "Alice Johnson", Email = "alice.johnson@example.com" };
        var customer2 = new Customer { Id = Guid.NewGuid(), Name = "Bob Smith", Email = "bob.smith@example.com" };
        var customer3 = new Customer { Id = Guid.NewGuid(), Name = "Charlie Brown", Email = "charlie.brown@example.com" };
        var customer4 = new Customer { Id = Guid.NewGuid(), Name = "Diana Prince", Email = "diana.prince@example.com" };

        dbContext.Customers.AddRange(new List<Customer>
        {
            customer1, customer2, customer3, customer4
        });

        // Lägg till bokningar
        dbContext.Bookings.AddRange(new List<Booking>
        {
            new Booking
            {
                Id = Guid.NewGuid(),
                CustomerId = customer1.Id,
                RoomNumber = "101",
                CheckInDate = DateTime.Now.Date,
                CheckOutDate = DateTime.Now.Date.AddDays(3)
            },
            new Booking
            {
                Id = Guid.NewGuid(),
                CustomerId = customer2.Id,
                RoomNumber = "102",
                CheckInDate = DateTime.Now.Date.AddDays(1),
                CheckOutDate = DateTime.Now.Date.AddDays(4)
            },
            new Booking
            {
                Id = Guid.NewGuid(),
                CustomerId = customer3.Id,
                RoomNumber = "103",
                CheckInDate = DateTime.Now.Date.AddDays(2),
                CheckOutDate = DateTime.Now.Date.AddDays(5)
            },
            new Booking
            {
                Id = Guid.NewGuid(),
                CustomerId = customer4.Id,
                RoomNumber = "104",
                CheckInDate = DateTime.Now.Date.AddDays(3),
                CheckOutDate = DateTime.Now.Date.AddDays(6)
            }
        });
    }
}
