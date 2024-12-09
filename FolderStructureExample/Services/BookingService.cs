using FolderStructureExample.Models;
using FolderStructureExample.Repositories;

namespace FolderStructureExample.Services;

public class BookingService
{
    private readonly IBookingRepository _bookingRepository;

    public BookingService(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    public List<Booking> GetAllBookings()
    {
        return _bookingRepository.GetAll();
    }

    public Booking? GetBookingById(Guid id)
    {
        return _bookingRepository.GetById(id);
    }

    public void AddBooking(Booking booking)
    {
        // Validera bokning (exempel: kontrollera om check-in är före check-out)
        if (booking.CheckInDate >= booking.CheckOutDate)
        {
            throw new Exception("Check-out date must be after check-in date.");
        }

        // Lägg till bokning
        _bookingRepository.Add(booking);
    }

    public void UpdateBooking(Booking booking)
    {
        // Validera bokning
        if (booking.CheckInDate >= booking.CheckOutDate)
        {
            throw new Exception("Check-out date must be after check-in date.");
        }

        // Uppdatera bokning
        _bookingRepository.Update(booking);
    }

    public void DeleteBooking(Guid id)
    {
        _bookingRepository.Delete(id);
    }
}
