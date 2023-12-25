using System.Net.Http;
using System;
using System.Threading.Tasks;
namespace DAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my small discord api app\nthis technically breaks discord TOS\nso don't blame me if you get banned\n\n");
            string authorizationToken = ValidateInput("Enter your discord token:", 70);
            string ChannelID = ValidateInput("Enter ChannelID:", 19);
            var client = new HttpClient();
            client.BaseAddress = new Uri($"https://discord.com/api/v9/channels/{ChannelID}/typing");
            Task.Run(async () =>
            {
                while (true)
                {
                    var request = new HttpRequestMessage(HttpMethod.Post, "");
                    request.Headers.Add("Authorization", authorizationToken);
                    var response = await client.SendAsync(request);

                    Console.WriteLine(response.IsSuccessStatusCode ? "Typing..." : $"Failed to send typing status. Status code: {response.StatusCode}");
                    await Task.Delay(6000);
                }
            });
            Console.ReadLine(); // Keep the console window open
        }
        static string ValidateInput(string prompt, int expectedLength)
        {
            string input;
            do
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine();
            } while (input.Length != expectedLength);

            return input;
        }
    }
}
