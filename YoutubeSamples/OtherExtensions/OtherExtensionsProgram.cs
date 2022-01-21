using static YoutubeSamples.OtherExtensions.ObjectExtensions;
MyClass mine1 = new MyClass();
MyClass mine2 = new MyClass();
MyClass mine3 = new MyClass();

mine1.ThrowIfNull();   // mine1 is the Name of the Argument
mine2.ThrowIfNull();  // mine2 is the Name of the Argument
mine3.ThrowIfNull(); // mine3 is the Name of the Argument

public class MyClass
{
    public string  Name { get; set; }
}





