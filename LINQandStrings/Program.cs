List<string> fruits = new List<string>
{
    "Apple", "Banana", "Strawberry", "Cherry", "Mango",
                "Blueberry", "Blackberry", "Bettyroot", "Avocado", "Carrot",
                "Broccoli", "Cucumber", "Bell Pepper", "Beetroot", "Pear",
                "Orange", "Grape", "Peach", "Nectarine", "Watermelon"
};

StringStartwithB(fruits);
StringContainsBerry(fruits);
StringStartwithAtoM(fruits);
CountofNtoZ(fruits);
LongestString(fruits);
static void StringStartwithB(List<string> items)
{
    var result = items.Where(s => s.StartsWith("B") || s.StartsWith("b"));
    Console.WriteLine("Strings starting with B or b:");
    Console.WriteLine("----------------------------\n");
    foreach (var item in result)
    {
        Console.WriteLine(item);
    }
}

static void StringContainsBerry(List<string> items)
{
    var result = items.Where(s => s.Contains("berry") );
    Console.WriteLine("Strings contains berry:");
    Console.WriteLine("----------------------\n");
    foreach (var item in result)
    {
        Console.WriteLine(item);
    }
}


static void StringStartwithAtoM(List<string> items)
{
    var result = items.Where(s => s[0]>='A' && s[0]<='M');
    Console.WriteLine("Strings starting with the letters A-M");
    Console.WriteLine("-------------------------------------\n");
    foreach (var item in result)
    {
        Console.WriteLine(item);
    }
}

static void CountofNtoZ(List<string> items)
{
    var result = items.Where(s => s[0] >= 'N' && s[0] <= 'Z').Count();
    Console.WriteLine("Count of strings start with the letters N-Z");
    Console.WriteLine("-------------------------------------------\n");
    Console.WriteLine(result);
    
}

static void LongestString(List<string> items)
{
    var result = items.OrderByDescending(s=>s.Length).First();
    Console.WriteLine("Longest string in the list");
    Console.WriteLine("--------------------------\n");
    Console.WriteLine(result);

}
