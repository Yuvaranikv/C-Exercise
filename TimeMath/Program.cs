
Console.Write("Enter a time (hh:mm): ");
string timeInput = Console.ReadLine();

TimeSpan time;
while (!TimeSpan.TryParseExact(timeInput, @"hh\:mm", null, out time))
{
    Console.Write("Invalid time format. Please enter a time in the format hh:mm: ");
    timeInput = Console.ReadLine();
}
Console.Write("Enter the number of minutes to add: ");
int minutesToAdd;
while (!int.TryParse(Console.ReadLine(), out minutesToAdd))
{
    Console.Write("Invalid input. Please enter a valid number of minutes: ");
}
TimeSpan newTime = time.Add(TimeSpan.FromMinutes(minutesToAdd));

// Display the new time in the format hh:mm
Console.WriteLine($"New time: {newTime:hh\\:mm}");