using System.Net.Http.Json;
using System.Text.Json;

namespace SseConnector;

public record struct TokenResponse(string AccessToken, string RefreshToken);
public record struct EmployeeStatus(string EmployeeUId, int Status);

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

        Dictionary<string, string> EmployeesMap = new()
        {
            {"270d6d13-7271-45e6-9f58-de6601af28bf", "Edygov.A"},
            {"af9f3a32-a19c-4dca-b950-ff1784801656", "Kimryakov.A"},
            {"b70d8271-f4f9-4bd2-ad91-92dcb196cd8b", "Tremaskin.A"},
            {"b08ecce0-b9b1-4e6e-a261-6d83de0890af", "Nikulin.P"},
        };

        Dictionary<int, string> StatusMap = new()
        {
            {1 , "Online" },
            {5 , "Offline" },
            {0 , "None" },
        };

        var response = await client.PostAsJsonAsync(loginUrl, loginData);
        var tokens = await response.Content.ReadFromJsonAsync<TokenResponse>();
        System.Console.WriteLine(tokens);


        while (true) {
            try
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokens.AccessToken);
                System.Console.WriteLine("SSE connection");
                using (var streamReader = new StreamReader(await client.GetStreamAsync(url)))
                {
                    while (!streamReader.EndOfStream)
                    {
                        var message = await streamReader.ReadLineAsync();
                        if (message!.StartsWith("data: "))
                        {
                            var jsonMessage = JsonSerializer.Deserialize<EmployeeStatus>(message.Replace("data: ", ""));
                            System.Console.WriteLine($"SSE update: {EmployeesMap[jsonMessage!.EmployeeUId]} - {StatusMap[jsonMessage!.Status]}");
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