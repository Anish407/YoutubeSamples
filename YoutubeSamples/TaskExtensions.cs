using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace YoutubeSamples
{
    public class TaskExtensions
    {
        public static async Task<IEnumerable<T>> WhenAllExtension<T>(params Task<T>[] args)
        {
            var allTasks = Task.WhenAll(args);
            try
            {
                // Dont handle the exceptions inside the catch block.. Let all the tasks complete then check the exception property
               return await allTasks;
            }
            catch (AggregateException ax)
            {
                //This will not be invoked
                Console.WriteLine(ax.Flatten().Message);
            }
            catch (Exception ex)
            {
                 // Ignore the exceptions thrown by WhenAll and let it complete.
                // We can get all the exceptions as an aggregate (in the Exception property).
            }
            
            //if the call reaches this line means that an exception was thrown and the exception property will not be null.
            throw allTasks.Exception ?? new Exception("This will not get called"); // just to return something.
        }
    }
}
