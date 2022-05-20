using System;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;



namespace TeeterNYCProject
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //connect to twitterAPI
            var userCredentials = new TwitterCredentials("4ygYBawbzLCnoE9lsr0xtn5Qs", "MlKShTX7Dtcg7otZSxY5BcZO9e4DVgyYurd4SDcA8WIFVZ15Sh", "1468216303420903425-blYdPOgof5hmgrQUfrHKiHgBn8cy2g", "wocRHayEr7CV5x1sPAlVjS3Q7KUu0S2attQ4oAlO1290v");
            var userClient = new TwitterClient(userCredentials);

            //keywords for twt collection
            var stream = userClient.Streams.CreateFilteredStream();
            stream.AddTrack("Javascript");

            stream.MatchingTweetReceived += (sender, eventReceived) =>
            {
                Console.WriteLine(eventReceived.Tweet);
            };

            await stream.StartMatchingAnyConditionAsync();
        }
    }
}