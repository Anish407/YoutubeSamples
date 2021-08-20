using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace YoutubeSamples
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var stopwatch = Stopwatch.StartNew();

            #region Without whenAll

            //var totalLikes = await GetResult("GetLikes");
            //var totalFrnds = await GetResult("TotalFrnds");
            //var TotalFollowers = await GetResult("TotalFollowers");

            //stopwatch.Stop();
            //Console.WriteLine($"Time Take: {stopwatch.ElapsedMilliseconds}, Likes: {totalLikes}, frnds:{totalFrnds}, followers:{TotalFollowers}");

            #endregion

            #region With Task.WhenAll
            stopwatch.Reset();
            stopwatch.Start();

            var totalLikesAsync = GetResult("GetLikes");
            var totalFrndsAsync = GetResult("TotalFrnds");
            var TotalFollowersAsync = GetResult("TotalFollowers");

            await Task.WhenAll(totalLikesAsync, totalFrndsAsync, TotalFollowersAsync);

            var frnds = totalFrndsAsync.Result;
            var folwrs = TotalFollowersAsync.Result;
            var likes = totalLikesAsync.Result;

            stopwatch.Stop()
            #endregion
           ;

            Console.WriteLine($"Time Take: {stopwatch.ElapsedMilliseconds}, " +
                $"Likes: {likes.Result}, " +
                $"frnds:{frnds.Result}, " +
                $"followers:{folwrs.Result}");




            Console.ReadLine();
        }




        static async Task<MyClass> GetResult(string apiName)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:5003/api/AsyncDemo/");
                var httpResponseMessage = await client.GetAsync(apiName);
                var content = await httpResponseMessage.Content.ReadAsStringAsync();
                if (httpResponseMessage.IsSuccessStatusCode)
                    return JsonSerializer.Deserialize<MyClass>(content);
                return new MyClass();
            }
            catch (AggregateException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public class MyClass
        {
            public int Result { get; set; }
        }


    }
}
