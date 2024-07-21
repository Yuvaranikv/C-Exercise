do
{
    for (int i = 0; i < 3; i++)
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        Console.Write("Enter your age on 31-December: ");
        if (int.TryParse(Console.ReadLine(), out int age))
        {
            int birthYear = GetBirthYear(age);
            Console.WriteLine($"{name} was born in {birthYear}");
        }
        else
        {
            Console.WriteLine("Invalid age entered. Please enter a valid number.");
        }
    }

    Console.Write("Do you want to enter another (yes/no)? ");
} while (Console.ReadLine().Trim().ToLower() == "yes");
static int GetBirthYear(int age)
{
    int currentYear = DateTime.Now.Year;
    return currentYear - age;
}