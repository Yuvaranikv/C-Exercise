using Delegate_Math;

BasicMath math = new BasicMath();

// Create delegate instances and use them to call the math methods
MathOperation mathOp;

// Call Add method
mathOp = new MathOperation(math.Add);
double addResult = mathOp(10, 5);
Console.WriteLine($"Addition Result: {addResult}");

// Call Subtract method
mathOp = new MathOperation(math.Subtract);
double subtractResult = mathOp(10, 5);
Console.WriteLine($"Subtraction Result: {subtractResult}");

// Call Multiply method
mathOp = new MathOperation(math.Multiply);
double multiplyResult = mathOp(10, 5);
Console.WriteLine($"Multiplication Result: {multiplyResult}");

// Call Divide method
mathOp = new MathOperation(math.Divide);
double divideResult = mathOp(10, 5);
Console.WriteLine($"Division Result: {divideResult}");
        

