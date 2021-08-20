using System;
using System.Threading.Tasks;

namespace YoutubeSamples
{
    public interface ITask
    {
        Task<string> DummyTask(int number);
    }

    public class SampleTask : ITask
    {
        public async Task<string> DummyTask(int number)
        {
            await Task.Delay(1000);
            return $"Pass: {number}";
        }
    }
    public class BrokenTask : ITask
    {
        public async Task<string> DummyTask(int number)
        {
            await Task.Delay(1000);
            throw new Exception($"Fail {number}");
            return $"Fail: {number}";
        }
    }
}