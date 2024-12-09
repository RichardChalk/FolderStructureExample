using FolderStructureExample.Models;

namespace FolderStructureExample.Data;

// Varför behövs denna klass?
// Centraliserad datahantering: Genom att samla alla listor i en
// klass har vi en plats där all "data" i applikationen lagras.
// Simulerar en databas:
// Om du senare vill introducera Entity Framework Core,
// kan du ersätta denna klass med en riktig DbContext.
public class ApplicationDbContext
{
    // En lista som simulerar databastabellen för kunder
    // OBS: Syntaxen är simplified! =[]
    public List<Customer> Customers { get; set; } = [];
    public List<Booking> Bookings { get; set; } = [];

    // Lägg till fler listor för andra modeller senare
}
