using FolderStructureExample.Models;

namespace FolderStructureExample.Repositories;

// ICustomerRepository, som ansvarar för att hantera
// dataoperationer för Customer.
// Även om vi använder en enkel lista just nu,
// skapar vi ett repository-lager för att förbereda för
// framtida förändringar (t.ex., när en riktig databas används).
public interface ICustomerRepository
{
    List<Customer> GetAll();
    Customer? GetById(Guid id);
    void Add(Customer customer);
    void Update(Customer customer);
    void Delete(Guid id);
}
