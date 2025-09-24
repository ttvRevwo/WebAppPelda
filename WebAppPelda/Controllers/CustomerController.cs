using WebAppPelda.Models;

namespace WebAppPelda.Controllers
{
    public class CustomerController
    {
        public List<Customer> GetCustomersFromDatabase()
        {

        }
        public List<Customer> GetCustomersFromFile()
        {
            List<Customer> customers = new List<Customer>();
            string[] lines = File.ReadAllLines("CustomersDatas.txt").Skip(1).ToArray();
            foreach (string sor in lines)
            {
                string[] mezok = sor.Split(';');
                customers.Add(new Customer
                {
                    Id = int.Parse(mezok[0]),
                    Name = mezok[1],
                    Phone = mezok[2],
                    Score = int.Parse(mezok[3])
                });
            }
            return customers;

            /*return new List<Customer>()
            {
                new Customer() { Id = 1, Name = "Alice", Phone = "111-222-3333", Score = 90 },
                new Customer() { Id = 2, Name = "Bob", Phone = "444-555-6666", Score = 75 },
                new Customer() { Id = 3, Name = "Charlie", Phone = "777-888-9999", Score = 85 },
                new Customer() { Id = 4, Name = "Gonzo", Phone = "66-123-9999", Score = 40 }
            };*/ //teszt bedrótozott adatokkal
        }
    }
}
