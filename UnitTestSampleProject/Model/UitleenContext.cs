using System.Data.Entity;

namespace UnitTestSampleProject.Model
{
    public class UitleenContext : DbContext
    {
        public UitleenContext() : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Uitleenbedrijf;Integrated Security=True;")
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Order> Orders { get; set; }

        //Gelukt DENK ik

        //Specify the '-Verbose' flag to view the SQL statements being applied to the target database.
        //Applying explicit migrations: [201812281257195_InitialCreate].
        //Applying explicit migration: 201812281257195_InitialCreate.
        //Running Seed method.

        // :D
        //kijk nu eens in de database huhhhhhh zo vet 
        //jaaa :D
        //en nu kan je dus daadwerkelijk shit gaan doen
        //kom eens naar program
    }
}
