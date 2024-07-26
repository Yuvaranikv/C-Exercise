using Microsoft.Data.SqlClient;

namespace NorthwindGrocery_ConsoleApp
{
    class Program
    {
        private static readonly string connectionString = "Server=WSAMZN-8N4B89TF;" +
            " Database=demo; User Id=sa; Password=Password@123; TrustServerCertificate=True;";


        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Northwind Grocery Console App");
                Console.WriteLine("1 - List all categories");
                Console.WriteLine("2 - List products in a specific category");
                Console.WriteLine("3 - List products in a price range");
                Console.WriteLine("4 - List all suppliers");
                Console.WriteLine("5 - List products from a specific supplier");
                Console.WriteLine("6 - Quit");
                Console.Write("Choose an option: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ListAllCategories();
                        break;
                    case "2":
                        ListProductsInCategory();
                        break;
                    case "3":
                        ListProductsInPriceRange();
                        break;
                    case "4":
                        ListAllSuppliers();
                        break;
                    case "5":
                       ListProductsFromSupplier();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        WaitForKeyPress();
                        break;
                }
            }
        }

        static void ListAllCategories()
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT CategoryName FROM Categories";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader["CategoryName"]);
                }

                reader.Close();
                connection.Close();
            }
            WaitForKeyPress();
        }


        static void ListProductsInCategory()
        {
            Console.Write("Enter the category name: ");
            string categoryName = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT ProductName FROM Products INNER JOIN Categories ON Products.CategoryID = Categories.CategoryID WHERE CategoryName = @CategoryName";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CategoryName", categoryName);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader["ProductName"]);
                }

                reader.Close();
                connection.Close();
            }
            WaitForKeyPress();
        }

        static void ListProductsInPriceRange()
        {
            Console.Write("Enter the minimum price: ");
            decimal minPrice = decimal.Parse(Console.ReadLine());
            Console.Write("Enter the maximum price: ");
            decimal maxPrice = decimal.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT ProductName, UnitPrice FROM Products WHERE UnitPrice BETWEEN @MinPrice AND @MaxPrice";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MinPrice", minPrice);
                command.Parameters.AddWithValue("@MaxPrice", maxPrice);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["ProductName"]}: {reader["UnitPrice"]:C}");
                }

                reader.Close();
                connection.Close();
            }
            WaitForKeyPress();
        }

        static void ListAllSuppliers()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT SupplierID, CompanyName FROM Suppliers";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["SupplierID"]}, Name: {reader["CompanyName"]}");
                }

                reader.Close();
                connection.Close();
            }
            WaitForKeyPress();
        }

        static void ListProductsFromSupplier()
        {
            Console.Write("Enter the supplier ID: ");
            int supplierId = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT ProductName FROM Products WHERE SupplierID = @SupplierID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SupplierID", supplierId);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader["ProductName"]);
                }

                reader.Close();
                connection.Close();
            }
            WaitForKeyPress();
        }

        static void WaitForKeyPress()
        {
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }
    }
}
