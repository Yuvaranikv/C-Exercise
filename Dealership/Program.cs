using Microsoft.Data.SqlClient;



namespace Dealership
{
    class Program
    {
        private static readonly string connectionString = "Server=WSAMZN-8N4B89TF; Database=Dealership; User Id=sa; Password=Password@123; TrustServerCertificate=True;";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Dealership Management Console App");
                Console.WriteLine("1 - List all available cars");
                Console.WriteLine("2 - List available cars with less than a specific odometer reading");
                Console.WriteLine("3 - List available cars with a specific make and model");
                Console.WriteLine("4 - List available cars between a specific price range");
                Console.WriteLine("5 - Sell a car");
                Console.WriteLine("6 - Change a car’s price");
                Console.WriteLine("7 - Delete a car from inventory");
                Console.WriteLine("8 - Quit");
                Console.Write("Choose an option: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ListAllAvailableCars();
                        break;
                    case "2":
                        ListAvailableCarsByOdometer();
                        break;
                    case "3":
                        ListAvailableCarsByMakeAndModel();
                        break;
                    case "4":
                        ListAvailableCarsByPriceRange();
                        break;
                    case "5":
                        SellCar();
                        break;
                    case "6":
                        ChangeCarPrice();
                        break;
                    case "7":
                        DeleteCar();
                        break;
                    case "8":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        WaitForKeyPress();
                        break;
                }
            }
        }

        static void ListAllAvailableCars()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Cars WHERE status = 'available'";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine("Available Cars:");
                while (reader.Read())
                {
                    Console.WriteLine($"Inventory Number: {reader["inventory_number"]}, VIN: {reader["vehicle_identification_number"]}, Make: {reader["make"]}, Model: {reader["model"]}, Year: {reader["year"]}, Odometer: {reader["odometer_reading"]}, Color: {reader["color"]}, Price: {reader["price"]}");
                }

                reader.Close();
            }
            WaitForKeyPress();
        }

        static void ListAvailableCarsByOdometer()
        {
            Console.Write("Enter the maximum odometer reading: ");
            int maxOdometer = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Cars WHERE status = 'available' AND odometer_reading <= @MaxOdometer";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaxOdometer", maxOdometer);
                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine($"Available Cars with Odometer <= {maxOdometer}:");
                while (reader.Read())
                {
                    Console.WriteLine($"Inventory Number: {reader["inventory_number"]}, VIN: {reader["vehicle_identification_number"]}, Make: {reader["make"]}, Model: {reader["model"]}, Year: {reader["year"]}, Odometer: {reader["odometer_reading"]}, Color: {reader["color"]}, Price: {reader["price"]}");
                }

                reader.Close();
            }
            WaitForKeyPress();
        }

        static void ListAvailableCarsByMakeAndModel()
        {
            Console.Write("Enter the make: ");
            string make = Console.ReadLine();
            Console.Write("Enter the model: ");
            string model = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Cars WHERE status = 'available' AND make = @Make AND model = @Model";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Make", make);
                command.Parameters.AddWithValue("@Model", model);
                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine($"Available Cars with Make = {make} and Model = {model}:");
                while (reader.Read())
                {
                    Console.WriteLine($"Inventory Number: {reader["inventory_number"]}, VIN: {reader["vehicle_identification_number"]}, Make: {reader["make"]}, Model: {reader["model"]}, Year: {reader["year"]}, Odometer: {reader["odometer_reading"]}, Color: {reader["color"]}, Price: {reader["price"]}");
                }

                reader.Close();
            }
            WaitForKeyPress();
        }

        static void ListAvailableCarsByPriceRange()
        {
            Console.Write("Enter the minimum price: ");
            decimal minPrice = decimal.Parse(Console.ReadLine());
            Console.Write("Enter the maximum price: ");
            decimal maxPrice = decimal.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Cars WHERE status = 'available' AND price BETWEEN @MinPrice AND @MaxPrice";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MinPrice", minPrice);
                command.Parameters.AddWithValue("@MaxPrice", maxPrice);
                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine($"Available Cars with Price between {minPrice} and {maxPrice}:");
                while (reader.Read())
                {
                    Console.WriteLine($"Inventory Number: {reader["inventory_number"]}, VIN: {reader["vehicle_identification_number"]}, Make: {reader["make"]}, Model: {reader["model"]}, Year: {reader["year"]}, Odometer: {reader["odometer_reading"]}, Color: {reader["color"]}, Price: {reader["price"]}");
                }

                reader.Close();
            }
            WaitForKeyPress();
        }

        static void SellCar()
        {
            Console.Write("Enter the inventory number of the car being sold: ");
            string inventoryNumber = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Cars WHERE inventory_number = @InventoryNumber";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@InventoryNumber", inventoryNumber);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Console.WriteLine($"Inventory Number: {reader["inventory_number"]}, VIN: {reader["vehicle_identification_number"]}, Make: {reader["make"]}, Model: {reader["model"]}, Year: {reader["year"]}, Odometer: {reader["odometer_reading"]}, Color: {reader["color"]}, Price: {reader["price"]}");

                    Console.Write("Enter sales date (YYYY-MM-DD): ");
                    string salesDate = Console.ReadLine();
                    Console.Write("Enter customer name: ");
                    string customerName = Console.ReadLine();
                    Console.Write("Enter customer phone: ");
                    string customerPhone = Console.ReadLine();
                    Console.Write("Enter payment method: ");
                    string paymentMethod = Console.ReadLine();
                    Console.Write("Enter payment amount: ");
                    decimal paymentAmount = decimal.Parse(Console.ReadLine());

                    reader.Close();

                    string insertSaleQuery = "INSERT INTO Sales (inventory_number, sales_date, customer_name, customer_phone, payment_method, payment_amount) VALUES (@InventoryNumber, @SalesDate, @CustomerName, @CustomerPhone, @PaymentMethod, @PaymentAmount)";
                    SqlCommand insertSaleCommand = new SqlCommand(insertSaleQuery, connection);
                    insertSaleCommand.Parameters.AddWithValue("@InventoryNumber", inventoryNumber);
                    insertSaleCommand.Parameters.AddWithValue("@SalesDate", salesDate);
                    insertSaleCommand.Parameters.AddWithValue("@CustomerName", customerName);
                    insertSaleCommand.Parameters.AddWithValue("@CustomerPhone", customerPhone);
                    insertSaleCommand.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                    insertSaleCommand.Parameters.AddWithValue("@PaymentAmount", paymentAmount);
                    insertSaleCommand.ExecuteNonQuery();

                    string updateCarStatusQuery = "UPDATE Cars SET status = 'sold' WHERE inventory_number = @InventoryNumber";
                    SqlCommand updateCarStatusCommand = new SqlCommand(updateCarStatusQuery, connection);
                    updateCarStatusCommand.Parameters.AddWithValue("@InventoryNumber", inventoryNumber);
                    updateCarStatusCommand.ExecuteNonQuery();

                    // Create receipt file
                    string receiptContent = $"Inventory Number: {inventoryNumber}\nSales Date: {salesDate}\nCustomer Name: {customerName}\nCustomer Phone: {customerPhone}\nPayment Method: {paymentMethod}\nPayment Amount: {paymentAmount}";

                    // Save file to current directory
                    string receiptFilePath = Path.Combine(Directory.GetCurrentDirectory(), $"{inventoryNumber}_receipt.txt");
                    File.WriteAllText(receiptFilePath, receiptContent);
                    Console.WriteLine("Car sold and sales information recorded. Receipt generated.");
                }
                else
                {
                    Console.WriteLine("Car not found.");
                }

                reader.Close();
            }
            WaitForKeyPress();
        }

        static void ChangeCarPrice()
        {
            Console.Write("Enter the inventory number of the car: ");
            string inventoryNumber = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Cars WHERE inventory_number = @InventoryNumber";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@InventoryNumber", inventoryNumber);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Console.WriteLine($"Inventory Number: {reader["inventory_number"]}, VIN: {reader["vehicle_identification_number"]}, Make: {reader["make"]}, Model: {reader["model"]}, Year: {reader["year"]}, Odometer: {reader["odometer_reading"]}, Color: {reader["color"]}, Price: {reader["price"]}");

                    Console.Write("Enter the new price: ");
                    decimal newPrice = decimal.Parse(Console.ReadLine());

                    reader.Close();

                    string updatePriceQuery = "UPDATE Cars SET price = @NewPrice WHERE inventory_number = @InventoryNumber";
                    SqlCommand updatePriceCommand = new SqlCommand(updatePriceQuery, connection);
                    updatePriceCommand.Parameters.AddWithValue("@NewPrice", newPrice);
                    updatePriceCommand.Parameters.AddWithValue("@InventoryNumber", inventoryNumber);
                    updatePriceCommand.ExecuteNonQuery();

                    Console.WriteLine("Car price updated.");
                }
                else
                {
                    Console.WriteLine("Car not found.");
                }

                reader.Close();
            }
            WaitForKeyPress();
        }

        static void DeleteCar()
        {
            Console.Write("Enter the inventory number of the car: ");
            string inventoryNumber = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Cars WHERE inventory_number = @InventoryNumber";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@InventoryNumber", inventoryNumber);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Console.WriteLine($"Inventory Number: {reader["inventory_number"]}, VIN: {reader["vehicle_identification_number"]}, Make: {reader["make"]}, Model: {reader["model"]}, Year: {reader["year"]}, Odometer: {reader["odometer_reading"]}, Color: {reader["color"]}, Price: {reader["price"]}");

                    Console.Write("Are you sure you want to delete this car? (yes/no): ");
                    string confirmation = Console.ReadLine();

                    if (confirmation.ToLower() == "yes")
                    {
                        reader.Close();

                        string deleteCarQuery = "DELETE FROM Cars WHERE inventory_number = @InventoryNumber";
                        SqlCommand deleteCarCommand = new SqlCommand(deleteCarQuery, connection);
                        deleteCarCommand.Parameters.AddWithValue("@InventoryNumber", inventoryNumber);
                        deleteCarCommand.ExecuteNonQuery();

                        Console.WriteLine("Car deleted from inventory.");
                    }
                    else
                    {
                        Console.WriteLine("Operation cancelled.");
                    }
                }
                else
                {
                    Console.WriteLine("Car not found.");
                }

                reader.Close();
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

