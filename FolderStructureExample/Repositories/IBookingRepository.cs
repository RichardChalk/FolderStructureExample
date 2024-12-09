using FolderStructureExample.Models;

namespace FolderStructureExample.Repositories;

public interface IBookingRepository
{
    List<Booking> GetAll();
    Booking? GetById(Guid id);
    void Add(Booking booking);
    void Update(Booking booking);
    void Delete(Guid id);
}
