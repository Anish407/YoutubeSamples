using System;
using System.Threading;
using System.Threading.Tasks;


Console.WriteLine("......Timer Started......");
Timer timer = new Timer(TimeSpan.FromSeconds(1));
Timer timer2 = new Timer(TimeSpan.FromSeconds(1));

timer.Start(async () =>
{
    await Task.Delay(TimeSpan.FromSeconds(1));
    Console.WriteLine($"Timer 1 {DateTime.Now}");
});

timer2.Start(async () =>
{
    await Task.Delay(TimeSpan.FromSeconds(1));
    Console.WriteLine($"Timer 2 {DateTime.Now}");
});


Console.WriteLine("......Press any key to stop the timer........");
Console.ReadLine();
await timer2.Stop();
Console.ReadLine();





public class Timer
{
    public Task? timerTask;
    private PeriodicTimer periodicTimer { get; }
    private CancellationTokenSource CancellationTokenSource = new();

    public Timer(TimeSpan timeSpan)
    {
        this.periodicTimer = new(timeSpan);
    }

    // make the method void so that control proceeds to the next line
    public void Start(Func<Task> operation)
    {
        // store the reference to the task
        timerTask = DoWorkAsync(operation);
    }

    public virtual async Task DoWorkAsync(Func<Task> operation)
    {
        try
        {
            while (await periodicTimer.WaitForNextTickAsync() && !CancellationTokenSource.Token.IsCancellationRequested)
            {
                await operation();
            }
        }
        catch (OperationCanceledException ex)
        {
            throw;
        }
    }

    public async Task Stop()
    {
        if (timerTask is null) return;

        CancellationTokenSource.Cancel();
        // lets the last iteration complete
        await timerTask;
        Console.WriteLine("........Task Cancelled........");
    }

}