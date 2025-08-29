using System.Net.Http.Json;

namespace SseConnector;

public record TokenResponse(string AccessToken, string RefreshToken);

class Program
{
    static async Task Main(string[] args)
    {
        HttpClient client = new();
        client.Timeout = TimeSpan.FromSeconds(5);
        string url = "http://localhost:8190/api/employee/getStatusStream";
        string loginUrl = "http://localhost:8190/api/auth/login";

        var loginData = new
        {
            Login = "Edygov.a",
            Password = "d3f4u7t"
        };

        var response = await client.PostAsJsonAsync(loginUrl, loginData);
        var tokens = await response.Content.ReadFromJsonAsync<TokenResponse>();
        System.Console.WriteLine(tokens);


        while (true) {
            try
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokens?.AccessToken);
                System.Console.WriteLine("SSE connection");
                using (var streamReader = new StreamReader(await client.GetStreamAsync(url)))
                {
                    while (!streamReader.EndOfStream)
                    {
                        var message = await streamReader.ReadLineAsync();
                        if (message!.StartsWith("data: ")) {
                            System.Console.WriteLine($"SSE update: {message}");
                        }
                    }    
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error: {ex.Message}");
                System.Console.WriteLine("Retry in 5 sec");
                await Task.Delay(TimeSpan.FromSeconds(5));
            }
        }
    }
}