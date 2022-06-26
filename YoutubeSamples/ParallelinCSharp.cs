using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;



IList<ITask> tasks = new List<ITask>
{
    new File1(),
    new File1(),
    new BrokenTask(),
    new File1(),
    new BrokenTask(),

};

//File1 f1 = new File1();
//var result1 = f1.DoSomething(2);
//File1 f2 = new File1();
//var result2 = f2.DoSomething(2);

List<Task> allTasks = new List<Task>();
for (int i = 0; i < tasks.Count(); i++)
{
    allTasks.Add(tasks[i].DoSomething(i));
}


await Task.WhenAll(allTasks);
//await Task.WhenAll(result1, result2);

Console.WriteLine("Completed");




public interface ITask
{
    Task DoSomething(int number);
}

public class File1 : ITask
{
    public async Task DoSomething(int number)
    {
        Console.WriteLine(number);
        await Task.Delay(5000);
    }
}

public class BrokenTask : ITask
{
    public async Task DoSomething(int number)
    {
        throw new System.Exception($"Failed {number}");
    }
}





