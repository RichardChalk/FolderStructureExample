using FolderStructureExample.Data;
using FolderStructureExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderStructureExample.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BookingRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Booking> GetAll()
        {
            return _dbContext.Bookings;
        }

        public Booking? GetById(Guid id)
        {
            return _dbContext.Bookings.FirstOrDefault(b => b.Id == id);
        }

        public void Add(Booking booking)
        {
            _dbContext.Bookings.Add(booking);
        }

        public void Update(Booking booking)
        {
            var existingBooking = GetById(booking.Id);
            if (existingBooking != null)
            {
                existingBooking.CustomerId = booking.CustomerId;
                existingBooking.CheckInDate = booking.CheckInDate;
                existingBooking.CheckOutDate = booking.CheckOutDate;
                existingBooking.RoomNumber = booking.RoomNumber;
            }
        }

        public void Delete(Guid id)
        {
            var booking = GetById(id);
            if (booking != null)
            {
                _dbContext.Bookings.Remove(booking);
            }
        }
    }
}
