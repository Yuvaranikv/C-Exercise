using Delegate_Payment;

PaymentMethods paymentMethods = new PaymentMethods();
PaymentProcessor paymentProcessor = new PaymentProcessor();

// Create delegate instances
PaymentHandler creditCardHandler = new PaymentHandler(paymentMethods.CreditCardPayment);
PaymentHandler payPalHandler = new PaymentHandler(paymentMethods.PayPalPayment);
PaymentHandler bankTransferHandler = new PaymentHandler(paymentMethods.BankTransferPayment);
PaymentHandler mastercardHandler = new PaymentHandler(paymentMethods.ProcessMastercardPayment);

// Process payments using different handlers and check for failure
bool isOk = paymentProcessor.ProcessPayment(creditCardHandler, "1234-1111-2222-1234", 100.00);
if (!isOk)
    Console.WriteLine("[ALERT] Payment processing failed");

isOk = paymentProcessor.ProcessPayment(payPalHandler, "paypal-user@example.com", 200.00);
if (!isOk)
    Console.WriteLine("[ALERT] Payment processing failed");

isOk = paymentProcessor.ProcessPayment(bankTransferHandler, "bank-account-12345", 300.00);
if (!isOk)
    Console.WriteLine("[ALERT] Payment processing failed");

isOk = paymentProcessor.ProcessPayment(mastercardHandler, "1234-5678-9101-1121", 400.00);
if (!isOk)
    Console.WriteLine("[ALERT] Payment processing failed");