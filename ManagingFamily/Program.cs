using ManagingFamily;

List<Person> people = new List<Person>();

while (true)
{
    Console.WriteLine("1. Add a person");
    Console.WriteLine("2. Display all people");
    Console.WriteLine("3. Display all people of a selected gender");
    Console.WriteLine("4. Display all people between a specified age range");
    Console.WriteLine("5. Exit");
    Console.Write("Enter your choice (1-5): ");
    string choice = Console.ReadLine();

    if (choice == "1")
    {
        // Add a person
        Console.Write("Enter name: ");
        string name = Console.ReadLine();

        Console.Write("Enter age: ");
        int age;
        while (!int.TryParse(Console.ReadLine(), out age) || age < 0)
        {
            Console.Write("Invalid input. Please enter a valid age: ");
        }

        Console.Write("Enter gender (Male/Female): ");
        string gender = Console.ReadLine();

        people.Add(new Person(name, age, gender));
    }

    else if (choice == "2")
    {
        // Display all people
        Console.WriteLine("Displaying all people:");
        foreach (var person in people)
        {
            person.Display();
        }
    }
    else if (choice == "3")
    {
        // Display all people of a selected gender
        Console.Write("Enter gender to filter (Male/Female): ");
        string gender = Console.ReadLine();

        var filteredPeople = people.Where(p => p.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase)).ToList();
        Console.WriteLine($"Displaying all people of gender: {gender}");
        foreach (var person in filteredPeople)
        {
            person.Display();
        }
    }
    else if (choice == "4")
    {
        // Display all people between a specified age range
        Console.Write("Enter minimum age: ");
        int minAge;
        while (!int.TryParse(Console.ReadLine(), out minAge) || minAge < 0)
        {
            Console.Write("Invalid input. Please enter a valid minimum age: ");
        }

        Console.Write("Enter maximum age: ");
        int maxAge;
        while (!int.TryParse(Console.ReadLine(), out maxAge) || maxAge < minAge)
        {
            Console.Write("Invalid input. Please enter a valid maximum age greater than or equal to minimum age: ");
        }

        var ageFilteredPeople = people.Where(p => p.Age >= minAge && p.Age <= maxAge).ToList();
        Console.WriteLine($"Displaying all people between ages {minAge} and {maxAge}");
        foreach (var person in ageFilteredPeople)
        {
            person.Display();
        }
    }
    else if (choice == "5")
    {
        // Exit
        break;
    }
    else
    {
        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
    }

    Console.WriteLine();
}

Console.WriteLine("Thank you for using the ManagingFamily application!");
        
