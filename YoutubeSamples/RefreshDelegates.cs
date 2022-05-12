using System;

static int Sum(int x, int y) => x + y;
static int Multiply(int x, int y) => x * y;
static double Divide(int x, int y) => x / y;
static int Subtract(int x, int y) => x - y;

Console.WriteLine("Enter 2 numbers");

int input1 = int.Parse(Console.ReadLine() ?? "1");
int input2 = int.Parse(Console.ReadLine() ?? "1");

Console.WriteLine("Enter 1 -> add, 2-> Multiply, 3-> Divide, 4-> Subtract ");
int operation = int.Parse(Console.ReadLine() ?? "1");

Func<string> func = () => "";
Action<string> action = s => { };

if (operation == 1) Console.WriteLine(Calculate(Sum, input1, input2));
else if (operation == 2) Console.WriteLine(Calculate(Multiply, input1, input2));
else if (operation == 3) Console.WriteLine(Calculate(Divide, input1, input2));
else if (operation == 4) Console.WriteLine(Calculate(Subtract, input1, input2));
else Console.WriteLine($"{operation} is not valid ");

Console.ReadLine();

Calculate(Sum, input1, input2);
Calculator<int, int> Add = Sum;
Calculator<int, int> Mult = Multiply;
Calculator<int, double> div = Divide;
Calculator<int, int> Minus = Subtract;


O Calculate<I, O>(Calculator<I, O> calculator, I item1, I item2)
{
    return calculator(item1, item2);
}

Console.WriteLine("Hello, World!");
public delegate O Calculator<I, O>(I item1, I item2);


