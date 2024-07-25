using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_Payment
{
    public delegate bool PaymentHandler(double amount);
    public class PaymentProcessor
    {
        public bool ProcessPayment(PaymentHandler paymentHandler, string accountNumber, double amount)
        {
            Console.WriteLine($"Processing payment for account {accountNumber}.");
            return paymentHandler(amount);
        }
    }

    public class PaymentMethods
    {
        public bool CreditCardPayment(double amount)
        {
            Console.WriteLine($"Processing credit card payment of {amount:C}.");
            // Simulate processing logic
            return true; // Assume payment is successful
        }

        public bool PayPalPayment(double amount)
        {
            Console.WriteLine($"Processing PayPal payment of {amount:C}.");
            // Simulate processing logic
            return true; // Assume payment is successful
        }

        public bool BankTransferPayment(double amount)
        {
            Console.WriteLine($"Processing bank transfer payment of {amount:C}.");
            // Simulate processing logic
            return true; // Assume payment is successful
        }

        public bool ProcessMastercardPayment(double amount)
        {
            Console.WriteLine($"Processing Mastercard payment of {amount:C}.");
            // Simulate processing logic
            return false; // Simulate a failed payment
        }
    }
}
