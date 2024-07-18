// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
        Console.WriteLine("Enter ur name : ");
string name = Console.ReadLine();

Console.WriteLine("hello"+name);

string name1 = "Yuvarani";
DateTime bday = new DateTime(1987, 8, 13);
decimal pay = (decimal)69759.25;

Console.WriteLine(
   "V1- {0} was born on {1:dd-MM-yyyy} and earns {2:C}",
   name1, bday, pay);

Console.WriteLine(
   $"V2- {name1} was born on {bday:dd-MM-yyyy} and earns {pay:C}");