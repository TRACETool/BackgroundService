
using HistoricalDataService;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using System.Net.Http.Json;

var connection = new HubConnectionBuilder()
    .WithUrl("http://localhost:5122/historicaldatahub") // SignalR Hub URL
    .Build();

connection.On<RepoDetailsDto>("ReceiveDataAsync", async (data) =>
{

    using var httpClient = new HttpClient();
    var json = JsonConvert.SerializeObject(data);
    Console.WriteLine(json);
    var url = $"http://127.0.0.1:8000/fetch_and_train_model?owner={data.Owner}&repo={data.Repository}&token={data.APIToken}";
    var response = await httpClient.PostAsJsonAsync(url, json);
    var send = await response.Content.ReadAsStringAsync();
    //var commits = JsonConvert.DeserializeObject<HistoricalCommitDump>(send);
    //var sendJson = JsonConvert.SerializeObject(commits);
    var sendToServer = await httpClient.PostAsJsonAsync("http://localhost:5122/api/repos/receivehub", send);
    
    await connection.InvokeAsync("ReceiveResponseAsync", await response.Content.ReadAsStringAsync());
    //Console.WriteLine($"FastAPI response: {await response.Content.ReadAsStringAsync()}");
});

await connection.StartAsync();
Console.WriteLine("Connected to SignalR Hub.");

// Keep the service running
await Task.Delay(Timeout.Infinite);