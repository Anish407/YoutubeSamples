using System;
using System.Runtime.CompilerServices;

namespace YoutubeSamples.OtherExtensions
{
    public static class ObjectExtensions
    {
        public static void ThrowIfNull<T>(this T  value, [CallerArgumentExpression("value")] string valueName= null)
        {
            Console.WriteLine($"{valueName} is the Name of the Argument");
           // if (value == null) throw new ArgumentNullException($"{valueName} is null");
        }


    }
}
