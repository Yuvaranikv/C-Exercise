// See https://aka.ms/new-console-template for more information
Console.WriteLine("Enter the first int number :");
int a=Convert.ToInt32( Console.ReadLine());
Console.WriteLine("Enter the second int number :");

int b =Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Sum :"+(a+b));
Console.WriteLine( "Differeence :"+(a-b));
Console.WriteLine("Product :"+(a*b));
Console.WriteLine("Quotient :"+(a/b)    );

Console.WriteLine("Enter the first double:");
string doubleInput1 = Console.ReadLine();
double double1 = Convert.ToDouble(doubleInput1);

Console.WriteLine("Enter the second double:");
string doubleInput2 = Console.ReadLine();
double double2 = Convert.ToDouble(doubleInput2);

Console.WriteLine("Sum :" + (double1 + double2));
Console.WriteLine("Differeence :" + (double1 - double2));
Console.WriteLine("Product :" + (double1 * double2));
Console.WriteLine("Quotient :" +( double1 / double2));
