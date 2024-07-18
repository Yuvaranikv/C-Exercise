// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var address = "Betty Smallwood|3329 Duchess|Erath, Texas";
string name=address.Split('|')[0];
string address1=address.Split("|")[1];
string city=address.Split("|")[2];
city = city.Split(",")[0];
string state=address.Split(",")[1];
Console.WriteLine($"Name :{ name}");
Console.WriteLine($"Address :{address1}");
Console.WriteLine($"City:{city}");
Console.WriteLine($"State :{state}");