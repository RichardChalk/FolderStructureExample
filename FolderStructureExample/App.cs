using FolderStructureExample.Controllers;
using FolderStructureExample.Data;
using FolderStructureExample.Repositories;
using FolderStructureExample.Services;
using FolderStructureExample.Utilities;

namespace FolderStructureExample;

public class App
{
    public static void Run()
    {
        var dbContext = new ApplicationDbContext();

        // Initiera data
        DataInitializer.Seed(dbContext);

        var customerRepository = new CustomerRepository(dbContext);
        var customerService = new CustomerService(customerRepository);
        var customerController = new CustomerController(customerService);

        var bookingRepository = new BookingRepository(dbContext);
        var bookingService = new BookingService(bookingRepository);
        var bookingController = new BookingController(bookingService);

        var menu = new DisplayMainMenu(customerController, bookingController);

        menu.ShowMenu();
    }
}
