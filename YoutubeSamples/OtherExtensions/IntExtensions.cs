// add the extension to the same namespace 
// rather than including all the different namespaces everywhere

namespace System
{
    public static class IntExtensions
    {
        public static TOutput Calculate<TInput, TOutput>(this TInput @input, Func<TInput, TOutput> func)
        => func(@input);
    }
}
