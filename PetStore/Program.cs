using PetStore;

List<InventoryItem> inventory = new List<InventoryItem>();

// Set the file path relative to the project's output directory
string filePath = @"D:\Users\yuvarani\Source\Repos\C-Exercise\PetStore\inventory.txt";

if (File.Exists(filePath))
{
    LoadInventoryFromFile(filePath, inventory);
}
else
{
    Console.WriteLine("Data file not found.");
}

while (true)
{
    Console.WriteLine("Pet Store Inventory Management");
    Console.WriteLine("1 - Show all items");
    Console.WriteLine("2 - Show item details");
    Console.WriteLine("3 - Add new item");
    Console.WriteLine("4 - Exit");
    Console.Write("Choose an option: ");

    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            ShowAllItems(inventory);
            break;
        case "2":
            ShowItemDetails(inventory);
            break;
        case "3":
            AddNewItem(inventory);
            break;
        case "4":
            return; // Exit the application
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}
        

        static void ShowAllItems(List<InventoryItem> inventory)
{
    Console.WriteLine("\nAll Inventory Items:");
    foreach (var item in inventory)
    {
        Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Type: {item.GetType().Name}");
    }
}

static void ShowItemDetails(List<InventoryItem> inventory)
{
    Console.Write("\nEnter the ID of the item to view details: ");
    if (int.TryParse(Console.ReadLine(), out int id))
    {
        var item = inventory.Find(i => i.Id == id);
        if (item != null)
        {
            Console.WriteLine("\nItem Details:");
            item.Display();
        }
        else
        {
            Console.WriteLine("Item not found.");
        }
    }
    else
    {
        Console.WriteLine("Invalid ID format.");
    }
}

static void AddNewItem(List<InventoryItem> inventory)
{
    Console.WriteLine("\nAdd New Item");

    Console.Write("Enter item type (Food, Accessory, Cage, Aquarium, Toy): ");
    string type = Console.ReadLine();

    Console.Write("Enter ID: ");
    if (int.TryParse(Console.ReadLine(), out int id))
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Description: ");
        string description = Console.ReadLine();

        Console.Write("Enter Price: ");
        if (double.TryParse(Console.ReadLine(), out double price))
        {
            Console.Write("Enter Quantity: ");
            if (int.TryParse(Console.ReadLine(), out int quantity))
            {
                InventoryItem newItem = null;

                switch (type)
                {
                    case "Food":
                        Console.Write("Enter Brand: ");
                        string brand = Console.ReadLine();

                        Console.Write("Enter Food Type (Dry, Wet): ");
                        FoodType foodType = Enum.Parse<FoodType>(Console.ReadLine(), true);

                        Console.Write("Enter Animal Type: ");
                        string animalType = Console.ReadLine();

                        newItem = new FoodItem
                        {
                            Id = id,
                            Name = name,
                            Description = description,
                            Price = price,
                            Quantity = quantity,
                            Brand = brand,
                            FoodType = foodType,
                            AnimalType = animalType
                        };
                        break;
                    case "Accessory":
                        Console.Write("Enter Size: ");
                        string size = Console.ReadLine();

                        Console.Write("Enter Color: ");
                        string color = Console.ReadLine();

                        newItem = new AccessoryItem
                        {
                            Id = id,
                            Name = name,
                            Description = description,
                            Price = price,
                            Quantity = quantity,
                            Size = size,
                            Color = color
                        };
                        break;
                    case "Cage":
                        Console.Write("Enter Dimensions: ");
                        string dimensions = Console.ReadLine();

                        Console.Write("Enter Material: ");
                        string material = Console.ReadLine();

                        newItem = new CageItem
                        {
                            Id = id,
                            Name = name,
                            Description = description,
                            Price = price,
                            Quantity = quantity,
                            Dimensions = dimensions,
                            Material = material
                        };
                        break;
                    case "Aquarium":
                        Console.Write("Enter Capacity: ");
                        if (int.TryParse(Console.ReadLine(), out int capacity))
                        {
                            Console.Write("Enter Shape: ");
                            string shape = Console.ReadLine();

                            newItem = new AquariumItem
                            {
                                Id = id,
                                Name = name,
                                Description = description,
                                Price = price,
                                Quantity = quantity,
                                Capacity = capacity,
                                Shape = shape
                            };
                        }
                        break;
                    case "Toy":
                        Console.Write("Enter Material: ");
                        string material1 = Console.ReadLine();

                        Console.Write("Enter Recommended Age: ");
                        if (int.TryParse(Console.ReadLine(), out int recommendedAge))
                        {
                            newItem = new ToyItem
                            {
                                Id = id,
                                Name = name,
                                Description = description,
                                Price = price,
                                Quantity = quantity,
                                Material = material1,
                                RecommendedAge = recommendedAge
                            };
                        }
                        break;
                    default:
                        Console.WriteLine("Unknown item type.");
                        break;
                }

                if (newItem != null)
                {
                    inventory.Add(newItem);
                    Console.WriteLine("Item added successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to add item.");
                }
            }
            else
            {
                Console.WriteLine("Invalid quantity.");
            }
        }
        else
        {
            Console.WriteLine("Invalid price.");
        }
    }
    else
    {
        Console.WriteLine("Invalid ID format.");
    }
}

static void LoadInventoryFromFile(string filePath, List<InventoryItem> inventory)
{
    using (StreamReader reader = new StreamReader(filePath))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            var parts = line.Split(',');

            if (parts.Length < 8)
            {
                Console.WriteLine($"Skipping invalid line: {line}");
                continue;
            }

            int id = int.Parse(parts[0]);
            string type = parts[1];
            string name = parts[2];
            string description = parts[3];
            double price = double.Parse(parts[4]);
            int quantity = int.Parse(parts[5]);

            InventoryItem item = null;

            switch (type)
            {
                case "Food":
                    item = new FoodItem
                    {
                        Id = id,
                        Name = name,
                        Description = description,
                        Price = price,
                        Quantity = quantity,
                        Brand = parts[6],
                        FoodType = Enum.Parse<FoodType>(parts[7], true),
                        AnimalType = parts[8]
                    };
                    break;
                case "Accessory":
                    item = new AccessoryItem
                    {
                        Id = id,
                        Name = name,
                        Description = description,
                        Price = price,
                        Quantity = quantity,
                        Size = parts[6],
                        Color = parts[7]
                    };
                    break;
                case "Cage":
                    item = new CageItem
                    {
                        Id = id,
                        Name = name,
                        Description = description,
                        Price = price,
                        Quantity = quantity,
                        Dimensions = parts[6],
                        Material = parts[7]
                    };
                    break;
                case "Aquarium":
                    item = new AquariumItem
                    {
                        Id = id,
                        Name = name,
                        Description = description,
                        Price = price,
                        Quantity = quantity,
                        Capacity = int.Parse(parts[6]),
                        Shape = parts[7]
                    };
                    break;
                case "Toy":
                    item = new ToyItem
                    {
                        Id = id,
                        Name = name,
                        Description = description,
                        Price = price,
                        Quantity = quantity,
                        Material = parts[6],
                        RecommendedAge = int.Parse(parts[7].Replace("months+", ""))
                    };
                    break;
                default:
                    Console.WriteLine($"Unknown item type: {type}");
                    break;
            }

            if (item != null)
            {
                inventory.Add(item);
            }
        }
    }
}
  
