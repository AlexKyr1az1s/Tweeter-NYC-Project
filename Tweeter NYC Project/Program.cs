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
            stream.AddTrack("python");
            stream.AddTrack("java");
            stream.AddTrack("c#");
            // Counters
            int c1 = 0;

            int c2 = 0;

            int c3 = 0;

            int c4 = 0;

            // Filters
            string f1 = "javascript";

            string f2 = "python";

            string f3 = "java";

            string f4 = "c#";

            stream.MatchingTweetReceived += (sender, eventReceived) =>
            {
                ITweet tweet = eventReceived.Tweet;
                string twttxt = eventReceived.Tweet.FullText;
                int x = tweet.FavoriteCount;
                string twtauthorname = tweet.CreatedBy.Name;

                //show twts
                Console.WriteLine("");
                Console.WriteLine(twtauthorname, " ", x);
                Console.WriteLine(eventReceived.Tweet);
                Console.WriteLine("");

                Console.WriteLine(f1, ":", c1, ", ", f2, ":", c2, ", ", f3, ":", c3, ", ", f4, ":", c4);

                //counters
                if (twttxt.Contains(f1))
                {
                    c1++;
                }

                if (twttxt.Contains(f2))
                {
                    c2++;
                }

                if (twttxt.Contains(f3))
                {
                    c3++;
                }

                if (twttxt.Contains(f4))
                {
                    c4++;
                }

                //Terminate
                if (twtcount == 100)
                {
                    stream.Stop();
                    Console.WriteLine("Complite!");
                }

                twtcount++;
            };

            await stream.StartMatchingAnyConditionAsync();
        }
    }
}