using System.ComponentModel.Design;
using System.Runtime.InteropServices;

List<string> movies=new List<string>();
string input;
Console.WriteLine("enter your movies type 'done' to finish");
while(true)
{
    Console.Write("Enter movie name");
   input= Console.ReadLine().Trim();
    if (input.ToLower() == "done")
        break;
    else
        if(!string.IsNullOrEmpty(input))
        movies.Add(input);  
}


movies.Sort(StringComparer.OrdinalIgnoreCase);
Console.WriteLine("Sorted list of movies");
foreach(var movie in movies) Console.WriteLine(movie);

while (true)
{
    Console.WriteLine("\nSearch for a movie:");
    Console.WriteLine("1. Partial Search");
    Console.WriteLine("2. Exact Search");
    Console.WriteLine("3. Exit");
    Console.Write("Enter your choice (1/2/3): ");
    string choice = Console.ReadLine();

    if (choice == "3")
    {
        break;
    }

    Console.Write("Enter the search term: ");
    string searchTerm = Console.ReadLine().Trim();

    if (choice == "1")
    {
        var partialMatches = movies.Where(m => m.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        if (partialMatches.Any()) {
            Console.WriteLine("Partial matches found");
            foreach (var partialMatch in partialMatches) {
                {
                    Console.WriteLine(partialMatch);
                }
            }

        }
        else
        {
            Console.WriteLine("No partial matches found.");
        }
    }

    else if (choice == "2")
    {
        // Exact Search
        bool exactMatch = movies.Any(m => string.Equals(m, searchTerm, StringComparison.OrdinalIgnoreCase));
        if (exactMatch)
        {
            Console.WriteLine($"Movie '{searchTerm}' was found in the list.");
        }
        else
        {
            Console.WriteLine($"Movie '{searchTerm}' was not found in the list.");
        }
    }
    else
    {
        Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
    }
}

Console.WriteLine("Thank you for using the Favorite Movies application!");
        
