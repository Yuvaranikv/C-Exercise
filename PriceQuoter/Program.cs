// See https://aka.ms/new-console-template for more information
using System.Xml;

Console.WriteLine("Enter Product Code");
var productcode = Console.ReadLine();
Console.WriteLine("Enter Quantity");
double unitPrice;
double OrderPrice;
int Quantity=Convert.ToInt32(Console.ReadLine());
double pricePerUnit = GetPricePerUnit(productcode, Quantity);
double TotalPrice=pricePerUnit*Quantity;
double discountedPrice = TotalPrice;
if(Quantity>=250)
{
    double discountPercentage = 15;
    double discountAmount = TotalPrice * (discountPercentage / 100);
    discountedPrice = TotalPrice - discountAmount;
    Console.WriteLine($"Large order discount applied: 15%");

    Console.WriteLine($"Product Code: {productcode}");
    Console.WriteLine($"Item Count: {Quantity}");
    Console.WriteLine($"Per Unit Price: {pricePerUnit:C}");
    Console.WriteLine($"Total Order Price: {TotalPrice:C}");

    if (Quantity >= 250)
    {
        Console.WriteLine($"Discounted Total Price: {discountedPrice:C}");
    }
}
else
{
    Console.WriteLine($"Product Code: {productcode}");
    Console.WriteLine($"Item Count: {Quantity}");
    Console.WriteLine($"Per Unit Price: {pricePerUnit:C}");
    Console.WriteLine($"Total Order Price: {TotalPrice:C}");
}

static double GetPricePerUnit(string productCode,int quantity)
{
    double pricePerUnit = -1;
    switch (productCode)
    {
        case "BG-127":
            if (quantity >= 1 && quantity <= 24)
                pricePerUnit = 18.99;
            else if (quantity >= 25 && quantity <= 50)
                pricePerUnit = 17.00;
            else if (quantity >= 51)
                pricePerUnit = 14.49;
            break;

        case "WRTR-28":
            if (quantity >= 1 && quantity <= 24)
                pricePerUnit = 125.00;
            else if (quantity >= 25 && quantity <= 50)
                pricePerUnit = 113.75;
            else if (quantity >= 51)
                pricePerUnit = 99.99;
            break;

        case "GUAC-8":
            if (quantity >= 1 && quantity <= 24)
                pricePerUnit = 8.99;
            else if (quantity >= 25 && quantity <= 50)
                pricePerUnit = 8.99;
            else if (quantity >= 51)
                pricePerUnit = 7.49;
            break;

        default:
            pricePerUnit = -1; // Invalid product code
            break;
    }

    return pricePerUnit;
}

