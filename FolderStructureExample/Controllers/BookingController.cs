using FolderStructureExample.Models;
using FolderStructureExample.Services;

namespace FolderStructureExample.Controllers;

public class BookingController
{
    private readonly BookingService _bookingService;

    public BookingController(BookingService bookingService)
    {
        _bookingService = bookingService;
    }

    public void ShowAllBookings()
    {
        var bookings = _bookingService.GetAllBookings();
        Console.WriteLine("\nList of Bookings:");
        foreach (var booking in bookings)
        {
            Console.WriteLine(booking); // Använder ToString() i Booking-klassen
        }
    }

    public void AddBooking()
    {
        Console.WriteLine("\nEnter customer ID:");
        if (!Guid.TryParse(Console.ReadLine(), out var customerId))
        {
            Console.WriteLine("Invalid Customer ID.");
            return;
        }

        Console.WriteLine("Enter room number:");
        var roomNumber = Console.ReadLine();

        Console.WriteLine("Enter check-in date (yyyy-MM-dd):");
        if (!DateTime.TryParse(Console.ReadLine(), out var checkInDate))
        {
            Console.WriteLine("Invalid date format.");
            return;
        }

        Console.WriteLine("Enter check-out date (yyyy-MM-dd):");
        if (!DateTime.TryParse(Console.ReadLine(), out var checkOutDate))
        {
            Console.WriteLine("Invalid date format.");
            return;
        }

        try
        {
            var booking = new Booking
            {
                Id = Guid.NewGuid(),
                CustomerId = customerId,
                RoomNumber = roomNumber!,
                CheckInDate = checkInDate,
                CheckOutDate = checkOutDate
            };

            _bookingService.AddBooking(booking);
            Console.WriteLine("Booking added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void UpdateBooking()
    {
        Console.WriteLine("\nEnter the ID of the booking to update:");
        if (!Guid.TryParse(Console.ReadLine(), out var id))
        {
            Console.WriteLine("Invalid Booking ID.");
            return;
        }

        var existingBooking = _bookingService.GetBookingById(id);
        if (existingBooking == null)
        {
            Console.WriteLine("Booking not found.");
            return;
        }

        Console.WriteLine("Enter new room number (leave blank to keep current):");
        var newRoomNumber = Console.ReadLine();

        Console.WriteLine("Enter new check-in date (leave blank to keep current, yyyy-MM-dd):");
        var newCheckInDateInput = Console.ReadLine();

        Console.WriteLine("Enter new check-out date (leave blank to keep current, yyyy-MM-dd):");
        var newCheckOutDateInput = Console.ReadLine();

        try
        {
            if (!string.IsNullOrWhiteSpace(newRoomNumber))
                existingBooking.RoomNumber = newRoomNumber;

            if (!string.IsNullOrWhiteSpace(newCheckInDateInput) && DateTime.TryParse(newCheckInDateInput, out var newCheckInDate))
                existingBooking.CheckInDate = newCheckInDate;

            if (!string.IsNullOrWhiteSpace(newCheckOutDateInput) && DateTime.TryParse(newCheckOutDateInput, out var newCheckOutDate))
                existingBooking.CheckOutDate = newCheckOutDate;

            _bookingService.UpdateBooking(existingBooking);
            Console.WriteLine("Booking updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    public void DeleteBooking()
    {
        Console.WriteLine("\nEnter the ID of the booking to delete:");
        if (Guid.TryParse(Console.ReadLine(), out var id))
        {
            _bookingService.DeleteBooking(id);
            Console.WriteLine("Booking deleted successfully.");
        }
        else
        {
            Console.WriteLine("Invalid ID format.");
        }
    }

    public void ShowBookingDetails()
    {
        Console.WriteLine("\nEnter the ID of the booking:");
        if (Guid.TryParse(Console.ReadLine(), out var id))
        {
            var booking = _bookingService.GetBookingById(id);
            if (booking != null)
            {
                Console.WriteLine($"\nBooking Details:\n{booking}");
            }
            else
            {
                Console.WriteLine("Booking not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID format.");
        }
    }
}
