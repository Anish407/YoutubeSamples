using System.Collections.Generic;
using System.Threading.Tasks;
using YoutubeSamples;

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

List<Task> results = new List<Task>();

for (int i = 0; i < tasks.Count; i++)
{
    results.Add(tasks[i].DummyTask(i).ContinueWith(async t =>
    {
        if (t.Status == TaskStatus.RanToCompletion)
        {
            Console.WriteLine( await t);
        }

        if (t.Status == TaskStatus.Faulted)
        {
          Console.WriteLine(t.Exception.Message); 
        }
    }));
}

await Task.WhenAll(results);
