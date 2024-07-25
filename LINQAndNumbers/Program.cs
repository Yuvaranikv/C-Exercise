int[] numbers = GenerateRandomNumbers(50,1,10000);

ListNosinAscendingOrder(numbers);
ListNumbersUnder100InDescendingOrder(numbers);
ListEvenNumbersInOriginalOrder(numbers);
FindMinMaxAndSum(numbers);
static int[] GenerateRandomNumbers(int count,int min,int max)
{
    Random random = new Random();
    int[] numbers=new int[count];
    for (int i=0; i<count; i++)
        numbers[i]=random.Next(min,max+1);
    return numbers;
}

static void ListNosinAscendingOrder(int[] numbers)
{
    var sortedNumbers = numbers.OrderBy(x => x);
    Console.WriteLine("Numbers in ascending order:");
    foreach (var number in sortedNumbers)
    {
        Console.WriteLine(number);
    }
}
static void ListNumbersUnder100InDescendingOrder(int[] numbers)
{
    var filteredNumbers = numbers.Where(n => n < 100).OrderByDescending(n => n);
    Console.WriteLine("\nNumbers under 100 in descending order:");
   
    if (filteredNumbers.Any())
    {
        foreach (var number in filteredNumbers)
        {
            Console.WriteLine(number);
        }
    }
    else
        Console.WriteLine("No numbers found");
}

static void ListEvenNumbersInOriginalOrder(int[] numbers)
{
    var evenNumbers = numbers.Where(n => n % 2 == 0);
    Console.WriteLine("\nEven numbers in original order:");
    foreach (var number in evenNumbers)
    {
        Console.WriteLine(number);
    }
}

static void FindMinMaxAndSum(int[] numbers)
{
    int minNumber = numbers.Min();
    int maxNumber = numbers.Max();
    int sum = numbers.Sum();

    Console.WriteLine("\nStatistics:");
    Console.WriteLine($"Minimum number: {minNumber}");
    Console.WriteLine($"Maximum number: {maxNumber}");
    Console.WriteLine($"Sum of all numbers: {sum}");
}