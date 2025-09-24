using MySql.Data.MySqlClient;
using WebAppPelda.Models;

namespace WebAppPelda.Controllers
{
    public class CustomerController
    {
        static MySqlConnection SQLConnection;

        private static void BuildConnection()
        {
            string connectionString = "SERVER = localhost;" +
                                      "DATABASE= uzlet;" +
                                      "UID = root;" +
                                      "PASSWORD =;" +
                                      "SSL MODE= none;";
            SQLConnection = new MySqlConnection();
            SQLConnection.ConnectionString = connectionString;

        }
        public List<Customer> GetCustomersFromDatabase()
        {
            BuildConnection();
            SQLConnection.Open();
            string sql = "SELECT * FROM customer";
            MySqlCommand command = new MySqlCommand(sql, SQLConnection);
            MySqlDataReader reader = command.ExecuteReader();
            List<Customer> customers = new List<Customer>();
            while (reader.Read())
            {
                customers.Add(new Customer
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    Phone = reader.GetString("phone"),
                    Score = reader.GetInt32("score")
                });
            }
            SQLConnection.Close();
            return customers;
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
