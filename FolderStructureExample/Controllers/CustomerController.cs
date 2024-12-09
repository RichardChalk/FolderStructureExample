using FolderStructureExample.Models;
using FolderStructureExample.Services;

namespace FolderStructureExample.Controllers;

// Vad gör den här klassen?
// Anropar controllers: Baserat på användarens val, vidarebefordrar
// den anrop till rätt metod i CustomerController.
// Fortsätter i en loop: Kör menyn tills användaren väljer att
// avsluta applikationen.
public class CustomerController
{
    private readonly CustomerService _customerService;

    public CustomerController(CustomerService customerService)
    {
        _customerService = customerService;
    }

    public void ShowAllCustomers()
    {
        var customers = _customerService.GetAllCustomers();
        Console.WriteLine("\nList of Customers:");
        foreach (var customer in customers)
        {
            Console.WriteLine(customer); // Använder ToString()
        }
    }

    public void ShowCustomerDetails()
    {
        Console.WriteLine("\nEnter the ID of the customer:");
        if (Guid.TryParse(Console.ReadLine(), out var id))
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer != null)
            {
                Console.WriteLine($"\nCustomer Details:\n{customer}");
            }
            else
            {
                Console.WriteLine("Customer not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID format.");
        }
    }

    public void AddCustomer()
    {
        Console.WriteLine("\nEnter customer name:");
        var name = Console.ReadLine();

        Console.WriteLine("Enter customer email:");
        var email = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email))
        {
            Console.WriteLine("Name and email cannot be empty.");
            return;
        }
        try
        {
            var customer = new Customer { Id = Guid.NewGuid(), Name = name, Email = email };
            _customerService.AddCustomer(customer);
            Console.WriteLine("Customer added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void UpdateCustomer()
    {
        Console.WriteLine("\nEnter the ID of the customer to update:");
        if (Guid.TryParse(Console.ReadLine(), out var id))
        {
            var existingCustomer = _customerService.GetCustomerById(id);
            if (existingCustomer == null)
            {
                Console.WriteLine("Customer not found.");
                return;
            }

            Console.WriteLine("Enter new name (leave blank to keep current):");
            var newName = Console.ReadLine();
            Console.WriteLine("Enter new email (leave blank to keep current):");
            var newEmail = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(newName))
                existingCustomer.Name = newName;

            if (!string.IsNullOrWhiteSpace(newEmail))
                existingCustomer.Email = newEmail;

            _customerService.UpdateCustomer(existingCustomer);
            Console.WriteLine("Customer updated successfully.");
        }
        else
        {
            Console.WriteLine("Invalid ID format.");
        }
    }


    public void DeleteCustomer()
    {
        Console.WriteLine("\nEnter the ID of the customer to delete:");
        if (Guid.TryParse(Console.ReadLine(), out var id))
        {
            _customerService.DeleteCustomer(id);
            Console.WriteLine("Customer deleted successfully.");
        }
        else
        {
            Console.WriteLine("Invalid ID format.");
        }
    }
}
