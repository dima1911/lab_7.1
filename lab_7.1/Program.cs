using System;

class Calculator<T>
{
    public delegate T OperationDelegate(T x, T y);

    public OperationDelegate Add { get; set; }
    public OperationDelegate Subtract { get; set; }
    public OperationDelegate Multiply { get; set; }
    public OperationDelegate Divide { get; set; }

    public Calculator(OperationDelegate add, OperationDelegate subtract, OperationDelegate multiply, OperationDelegate divide)
    {
        Add = add;
        Subtract = subtract;
        Multiply = multiply;
        Divide = divide;
    }

    public T PerformOperation(T x, T y, OperationDelegate operation)
    {
        if (operation != null)
            return operation(x, y);
        else
            throw new ArgumentException("Invalid operation delegate");
    }
}

class Program
{
    static void Main()
    {
        // Для цілочислових типів даних
        Calculator<int> intCalculator = new Calculator<int>(
            add: (x, y) => x + y,
            subtract: (x, y) => x - y,
            multiply: (x, y) => x * y,
            divide: (x, y) => x / y
        );

        int resultIntAdd = intCalculator.PerformOperation(5, 3, intCalculator.Add);
        int resultIntSubtract = intCalculator.PerformOperation(5, 3, intCalculator.Subtract);
        int resultIntMultiply = intCalculator.PerformOperation(5, 3, intCalculator.Multiply);
        int resultIntDivide = intCalculator.PerformOperation(5, 3, intCalculator.Divide);

        Console.WriteLine($"Integers: {resultIntAdd}, {resultIntSubtract}, {resultIntMultiply}, {resultIntDivide}");

        // Для дійсних чисел
        Calculator<double> doubleCalculator = new Calculator<double>(
            add: (x, y) => x + y,
            subtract: (x, y) => x - y,
            multiply: (x, y) => x * y,
            divide: (x, y) => x / y
        );

        double resultDoubleAdd = doubleCalculator.PerformOperation(5.5, 3.2, doubleCalculator.Add);
        double resultDoubleSubtract = doubleCalculator.PerformOperation(5.5, 3.2, doubleCalculator.Subtract);
        double resultDoubleMultiply = doubleCalculator.PerformOperation(5.5, 3.2, doubleCalculator.Multiply);
        double resultDoubleDivide = doubleCalculator.PerformOperation(5.5, 3.2, doubleCalculator.Divide);

        Console.WriteLine($"Doubles: {resultDoubleAdd}, {resultDoubleSubtract}, {resultDoubleMultiply}, {resultDoubleDivide}");
    }
}
