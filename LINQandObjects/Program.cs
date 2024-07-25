using LINQandObjects;

List<Person> list = new List<Person> { 
            new Person { Name = "John", Gender = "Male", Age = 24, Hometown = "New York" },
            new Person { Name = "Alice", Gender = "Female", Age = 30, Hometown = "Chicago" },
            new Person { Name = "Bob", Gender = "Male", Age = 19, Hometown = "New York" },
            new Person { Name = "Carol", Gender = "Female", Age = 22, Hometown = "Los Angeles" },
            new Person { Name = "Dave", Gender = "Male", Age = 27, Hometown = "Chicago" },
            new Person { Name = "Eve", Gender = "Female", Age = 24, Hometown = "San Francisco" },
            new Person { Name = "Frank", Gender = "Male", Age = 21, Hometown = "Seattle" },
            new Person { Name = "Grace", Gender = "Female", Age = 25, Hometown = "Boston" },
            new Person { Name = "Hank", Gender = "Male", Age = 32, Hometown = "Miami" },
            new Person { Name = "Ivy", Gender = "Female", Age = 19, Hometown = "New York" },
            new Person { Name = "Jack", Gender = "Male", Age = 18, Hometown = "San Francisco" },
            new Person { Name = "Karen", Gender = "Female", Age = 28, Hometown = "Chicago" },
            new Person { Name = "Leo", Gender = "Male", Age = 35, Hometown = "Boston" },
            new Person { Name = "Mia", Gender = "Female", Age = 20, Hometown = "Seattle" },
            new Person { Name = "Nick", Gender = "Male", Age = 22, Hometown = "Miami" },
            new Person { Name = "Olivia", Gender = "Female", Age = 31, Hometown = "Los Angeles" },
            new Person { Name = "Paul", Gender = "Male", Age = 29, Hometown = "San Francisco" },
            new Person { Name = "Quinn", Gender = "Female", Age = 26, Hometown = "Boston" },
            new Person { Name = "Rick", Gender = "Male", Age = 23, Hometown = "Chicago" },
            new Person { Name = "Sara", Gender = "Female", Age = 27, Hometown = "New York" },
};
ListMalesUnder25(list);
ListDistinctHometowns(list);
ListPeopleSortedByHometownAndName(list);
DisplayAverageAgeByGender(list);
ListHometownsAndCounts(list);
static void ListMalesUnder25(List<Person> people)
{
    var result = people.Where(p => p.Gender == "Male" && p.Age < 25).ToList();

    Console.WriteLine("Males under 25:");
    foreach (var person in result)
    {
        Console.WriteLine($"{person.Name} - {person.Age}");
    }
    Console.WriteLine();
}
static void ListDistinctHometowns(List<Person> people)
{
    var result = people.Select(p => p.Hometown).Distinct().OrderBy(ht => ht).ToList();

    Console.WriteLine("Distinct hometowns in ascending order:");
    foreach (var hometown in result)
    {
        Console.WriteLine(hometown);
    }
    Console.WriteLine();
}
static void ListPeopleSortedByHometownAndName(List<Person> people)
{
    var result = people.OrderBy(p => p.Hometown).ThenBy(p => p.Name).ToList();

    Console.WriteLine("People sorted by hometown:");
    foreach (var person in result)
    {
        Console.WriteLine($"{person.Hometown}: {person.Name}");
    }
    Console.WriteLine();
}

static void DisplayAverageAgeByGender(List<Person> people)
{
    var avgAgeWomen = people.Where(p => p.Gender == "Female").Average(p => p.Age);
    var avgAgeMen = people.Where(p => p.Gender == "Male").Average(p => p.Age);

    Console.WriteLine($"Average age of women: {avgAgeWomen}");
    Console.WriteLine($"Average age of men: {avgAgeMen}");
    Console.WriteLine();
}

static void ListHometownsAndCounts(List<Person> people)
{
    var result = people.GroupBy(p => p.Hometown)
                       .Select(group => new { Hometown = group.Key, Count = group.Count() })
                       .ToList();

    Console.WriteLine("Hometowns and the number of people from each hometown:");
    foreach (var group in result)
    {
        Console.WriteLine($"{group.Hometown}: {group.Count}");
    }
    Console.WriteLine();
}

