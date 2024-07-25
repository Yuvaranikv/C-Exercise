using Delegate_Logger;

Logger logger = new Logger();

// Create delegate instances and use them to call the log methods
LoggingOperation logOp;

// Call Info method
logOp = new LoggingOperation(logger.Info);
logOp("This is an info message.");

// Call Warning method
logOp = new LoggingOperation(logger.Warning);
logOp("This is a warning message.");

// Call Error method
logOp = new LoggingOperation(logger.Error);
logOp("This is an error message.");

// Create and use a delegate that references an anonymous method
logOp = delegate (string message)
{
    Console.WriteLine("[ALERT] " + message);
};
logOp("This is an alert message.");
        
