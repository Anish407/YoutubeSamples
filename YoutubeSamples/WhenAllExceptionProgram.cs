using System;
using System.Collections.Generic;
using System.Linq;
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
            IEnumerable<string> arr = new List<string>();


            #region Scenario 1 when using TaskExtensions.WhenAllExtension
            try
            {

                //use this to find all the exceptions when working with WhenAll
                arr = await TaskExtensions.WhenAllExtension(alltasks.ToArray());
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
            #endregion

            //var exception = res.Exception;

            #region Scenario 2 HANDLING EXCEPTIONS USING  Task.WhenAll
            var res = Task.WhenAll(alltasks.ToArray());

            try
            {
                arr = await res;
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.Flatten().Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var exceptions = res.Exception;
            Console.WriteLine(res.Exception.Message);
            #endregion

            //Scenario 3
            #region Handle And get the ones that worked and failed 
            IList<Task<(string, Exception)>> operations = new List<Task<(string, Exception)>>();

            for (int i = 0; i < tasks.Count; i++)
                operations.Add(WhenAllHelper(tasks[i].DummyTask(i)));

            await Task.WhenAll(operations);

            var failedOnes = operations.Where(i => i.Result.Item2 != null).ToList();
            var passedOnes = operations.Where(i => i.Result.Item1 != null).ToList();

            failedOnes.ForEach(async i => Console.WriteLine($"Failed : {await i}" ));
            passedOnes.ForEach(async i => Console.WriteLine($"Passed : {await i}"));
            #endregion
            Console.Read();

            async Task<(T, Exception)> WhenAllHelper<T>(Task<T> operation)
            {
                try
                {
                    return (await operation, null);
                }
                catch (Exception ex)
                {
                    return (default(T), ex);
                }
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
        static (int, string, int) Sum() 
        { 
            return (100, "anish", 200); 
        }


    }
}




