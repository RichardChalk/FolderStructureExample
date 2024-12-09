namespace FolderStructureExample.Models;

public class Customer
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    // Vad gör ToString() i en klass?
    // ToString() är en metod som finns i alla klasser i C#
    // eftersom den ärvs från basklassen Object.
    // Den används för att representera ett objekt som en sträng.

    // I vår Customer-klass har vi åsidosatt(overridden) standardimplementeringen
    // av ToString() för att ge en meningsfull representation av ett kundobjekt.
    // Detta gör att när objektet skrivs ut(t.ex., med Console.WriteLine()),
    // visas information om kunden istället för standardsträngen som annars
    // bara skulle vara typens namn(t.ex., HotelApp.Models.Customer).
    public override string ToString()
    {
        return $"ID: {Id}, Name: {Name}, Email: {Email}";
    }
}
