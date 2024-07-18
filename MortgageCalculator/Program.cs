// See https://aka.ms/new-console-template for more information
Console.WriteLine("How much are you borrowing ?");
    double A =Convert.ToDouble( Console.ReadLine());
Console.WriteLine("What is your interest rate");
double YIR=Convert.ToDouble(Console.ReadLine());
double MIR = YIR / 1200;
Console.WriteLine("How long is your loan?in years");
int  NP = Convert.ToInt32(Console.ReadLine());
NP = NP * 12;
double denominator = 1 - Math.Pow(1 + MIR, -NP);
double pmt = (A * MIR) / denominator;
Console.WriteLine("Your estimated payment is {0:C}", pmt);
Console.WriteLine($"Your estimated payment is {pmt:C}");
