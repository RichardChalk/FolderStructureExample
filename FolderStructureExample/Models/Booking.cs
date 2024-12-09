namespace FolderStructureExample.Models;

public class Booking
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; } // Referens till kunden som gör bokningen
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public string RoomNumber { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"Booking ID: {Id}, Customer ID: {CustomerId}\n Room: {RoomNumber}, " +
               $"Check-In: {CheckInDate:yyyy-MM-dd}, Check-Out: {CheckOutDate:yyyy-MM-dd}\n";
    }
}
