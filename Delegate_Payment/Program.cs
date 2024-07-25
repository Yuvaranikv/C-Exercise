using Delegate_Payment;

PaymentMethods paymentMethods = new PaymentMethods();
PaymentProcessor paymentProcessor = new PaymentProcessor();

// Create delegate instances
PaymentHandler creditCardHandler = new PaymentHandler(paymentMethods.CreditCardPayment);
PaymentHandler payPalHandler = new PaymentHandler(paymentMethods.PayPalPayment);
PaymentHandler bankTransferHandler = new PaymentHandler(paymentMethods.BankTransferPayment);

// Process payments using different handlers
Console.WriteLine("Credit Card Payment: " + paymentProcessor.ProcessPayment(creditCardHandler, "1234-5678-9101-1121", 100.00));
Console.WriteLine("PayPal Payment: " + paymentProcessor.ProcessPayment(payPalHandler, "paypal-user@example.com", 200.00));
Console.WriteLine("Bank Transfer Payment: " + paymentProcessor.ProcessPayment(bankTransferHandler, "bank-account-12345", 300.00));