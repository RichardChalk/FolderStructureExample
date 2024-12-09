using FolderStructureExample.Controllers;

namespace FolderStructureExample.Utilities;

// Vad gör den här klassen?
// Presenterar huvudmenyn: Visar en lista över tillgängliga alternativ
// för användaren.
public class DisplayMainMenu
{
    private readonly CustomerController _customerController;
    private readonly BookingController _bookingController;

    public DisplayMainMenu(CustomerController customerController, BookingController bookingController)
    {
        _customerController = customerController;
        _bookingController = bookingController;
    }

    public void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("\n=== Hotel Booking System ===");
            Console.WriteLine("1. Show all customers");
            Console.WriteLine("2. Add a customer");
            Console.WriteLine("3. Show customer details");
            Console.WriteLine("4. Update a customer");
            Console.WriteLine("5. Delete a customer");
            Console.WriteLine("6. Show all bookings");
            Console.WriteLine("7. Add a booking");
            Console.WriteLine("8. Show booking details");
            Console.WriteLine("9. Update a booking");
            Console.WriteLine("10. Delete a booking");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    _customerController.ShowAllCustomers();
                    break;
                case "2":
                    _customerController.AddCustomer();
                    break;
                case "3":
                    _customerController.ShowCustomerDetails();
                    break;
                case "4":
                    _customerController.UpdateCustomer();
                    break;
                case "5":
                    _customerController.DeleteCustomer();
                    break;

                case "6":
                    _bookingController.ShowAllBookings();
                    break;
                case "7":
                    _bookingController.AddBooking();
                    break;
                case "8":
                    _bookingController.ShowBookingDetails();
                    break;
                case "9":
                    _bookingController.UpdateBooking();
                    break;
                case "10":
                    _bookingController.DeleteBooking();
                    break;
                case "0":
                    Console.WriteLine("Exiting application...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
