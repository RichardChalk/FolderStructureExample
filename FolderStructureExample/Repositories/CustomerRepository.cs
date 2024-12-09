using FolderStructureExample.Data;
using FolderStructureExample.Models;

namespace FolderStructureExample.Repositories;

// Varför använda ett Repository?
// Separation av ansvar:
// Repositoryn hanterar dataoperationer så att andra delar av
// applikationen(som Services) inte behöver bry sig om detaljerna.

// Förberedelse för skalbarhet:
// Om du senare byter till en databas eller EF Core,
// kan du enkelt uppdatera repositoryn utan att påverka resten av applikationen.
public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _dbcontext;

    public CustomerRepository(ApplicationDbContext context)
    {
        _dbcontext = context;
    }

    public List<Customer> GetAll()
    {
        return _dbcontext.Customers;
    }

    public Customer? GetById(Guid id)
    {
        return _dbcontext.Customers.FirstOrDefault(c => c.Id == id);
    }

    public void Add(Customer customer)
    {
        _dbcontext.Customers.Add(customer);
    }

    public void Update(Customer customer)
    {
        var existingCustomer = GetById(customer.Id);
        if (existingCustomer != null)
        {
            existingCustomer.Name = customer.Name;
            existingCustomer.Email = customer.Email;
        }
    }

    public void Delete(Guid id)
    {
        var customer = GetById(id);
        if (customer != null)
        {
            _dbcontext.Customers.Remove(customer);
        }
    }
}
