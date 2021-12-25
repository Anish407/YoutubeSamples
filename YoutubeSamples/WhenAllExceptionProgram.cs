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

            //Scenario 2 when using Task.WhenAll
            //var res =  Task.WhenAll(alltasks.ToArray());
            try
            {
                //Scenario 1 when using TaskExtensions.WhenAllExtension
                //use this to find all the exceptions when working with WhenAll
                var res = await TaskExtensions.WhenAllExtension(alltasks.ToArray());

                //Scenario 2
                //Task.When All will return just one exception and 
                // await res;
            }
            catch (AggregateException ax)
            {
                Console.WriteLine(ax.Flatten().Message);
            }
            catch (Exception ax)
            {
                // dont catch the exception when using when all.. finally when the task completes
                // use the Exception property to get all the exceptions. Eg: ln 50  var exceptions = res.Exception;
                //Console.WriteLine(ax.Message);
            }

            var exceptions = res.Exception;
            Console.Read();
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




