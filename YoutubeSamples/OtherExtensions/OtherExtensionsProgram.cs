using static YoutubeSamples.OtherExtensions.ObjectExtensions;
using System;

sample(50);

void sample(int input)
{

    //int x = input + 5;
    //int y = x * 10;
    //int z = y / 10;
    //Console.WriteLine(z);

    // Int extensions
    // we create a lot of local variable and they will be in scope till the function exits
    // instead of doing the above we can use this extension method
    Console.WriteLine(input
        .Calculate(x => x + 5) // int
        .Calculate(x => x / 10.5) // returns a double
        .Calculate(x => "helloo") // returns a string
        );
}

MyClass mine1 = new MyClass();
MyClass mine2 = new MyClass();
MyClass mine3 = new MyClass();

mine1.ThrowIfNull();   // mine1 is the Name of the Argument
mine2.ThrowIfNull();  // mine2 is the Name of the Argument
mine3.ThrowIfNull(); // mine3 is the Name of the Argument

public class MyClass
{
    public string Name { get; set; }
}













