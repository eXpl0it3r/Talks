var client = new HttpClient();
client.BaseAddress = new Uri("http://localhost:3001");

var content = new StringContent("abc123");
var response = await client.PostAsync("login", content);
response.EnsureSuccessStatusCode();
var body = await response.Content.ReadAsStringAsync();
Console.WriteLine($"Response: {body}");