using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace YoutubeSamples
{
    public class WhenAllExceptionProgram
    {
        static async Task Main(string[] args)
        {
            //WhenAll only throws the first exception. If you had
            //100 tasks and 1 of them threw an exception, 
            //you don’t have access to the 99 tasks that completed successfully.

            var tasks = new List<ITask> {
                new SampleTask(),
                new SampleTask(),
                new SampleTask(),
                new SampleTask(),
                new BrokenTask(),
                new BrokenTask(),
                new SampleTask(),
                new BrokenTask(),
                new SampleTask()
            };

            List<Task<string>> alltasks = new List<Task<string>>();
            for (int i = 0; i < tasks.Count; i++)
                alltasks.Add(tasks[i].DummyTask(i));

            try
            {
              
                //use this to find all the exceptions when working with WhenAll
                var res = await TaskExtensions.WhenAllExtension(alltasks.ToArray());
                //Task.When All will return just one exception and 
                //var res = await Task.WhenAll(alltasks.ToArray());
            }
            catch (AggregateException ax)
            {
                Console.WriteLine(ax.Flatten().Message);
            }
            catch (Exception ax)
            {
                Console.WriteLine(ax.Message);
            }

            void sample(Func<int> myFunc)
            {
                try
                {
                    (_, _, int age) = Sum();
                }
                catch (Exception)
                {

                    throw;
                }

            }


            Console.ReadLine();
        }
        static (int, string, int) Sum() => (100, "anish", 200);


    }
}




