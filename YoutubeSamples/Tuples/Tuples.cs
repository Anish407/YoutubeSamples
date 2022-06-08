using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace YoutubeSamples.Tuples
{
    public class Tuples
    {
        public void SeriliazeTuple()
        {
            int age1;
            string firstName;
            // Tuples are converted to the generic type ValueTuple<> by the compiler
            // and it uses fields instead of properties to store its data internally
            // so while serializing we need to explicitly mention that we need to include 
            // fields inorder to get the data.

            (int age, string name) tupleData  = (10, "anish");
            tupleData.age = 110;

            // we can even map data to local variables 
            (age1, firstName)  = (10, "anish");

            // in the below case we map the value city to a local variable that 
            // is defined inside the tuple
            (age1, firstName, string city) = (10, "anish", "stockholm");

            // discarding values in a tuple,
            // we discard age and city
            // it can reduce memory usage
            (_, firstName, _) = (10, "anish", "stockholm");


            Console.WriteLine(city);

            // names will still be discarded
            string jsonData = JsonSerializer.Serialize(data, options: new() { IncludeFields = true });
            
        }
    }
}
