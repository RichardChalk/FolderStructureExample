using FolderStructureExample.Models;
using FolderStructureExample.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FolderStructureExample.Services;

// Varför använda en service?
// Affärslogik: Service-lagret hanterar affärslogik som t.ex.validering
// av data innan den skickas till repositoryn.
// Återanvändning: Du kan använda samma tjänst i flera controllers
// eller andra delar av applikationen.
public class CustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public List<Customer> GetAllCustomers()
    {
        return _customerRepository.GetAll();
    }

    public Customer? GetCustomerById(Guid id)
    {
        return _customerRepository.GetById(id);
    }

    public void AddCustomer(Customer customer)
    {
        // Affärslogik: Exempelvis kontrollera att e-post inte redan används
        var existingCustomer = _customerRepository.GetAll()
            .Find(c => c.Email == customer.Email);

        if (existingCustomer != null)
        {
            throw new System.Exception("A customer with this email already exists.");
        }

        _customerRepository.Add(customer);
    }

    public void UpdateCustomer(Customer customer)
    {
        // Affärslogik kan inkluderas här om det behövs
        _customerRepository.Update(customer);
    }

    public void DeleteCustomer(Guid id)
    {
        _customerRepository.Delete(id);
    }
}
