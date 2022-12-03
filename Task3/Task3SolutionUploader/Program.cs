using System.Net;
using System.Text;
using System.Text.Json;

var result = new Result();
result.values = new[] { File.ReadAllText("solution1e8") };
var serialize = JsonSerializer.Serialize(result);
using var handler = new HttpClientHandler();

var cookies = new CookieContainer();
cookies.Add(new Cookie("token",
    "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpZCI6Mzk3ODAwLCJtYXN0ZXJfaWQiOm51bGwsInJvbGVzIjpbXSwiZXhwIjoxNjcwMDc1NzM1LCJpbnRyYW5ldCI6ZmFsc2UsImF1dGhfdHlwZSI6ImV4dCIsInRhZ3MiOlsidGlua29mZl9lZHVjYXRpb24iXX0.izQKRwAOn18jgHBpmbSijGaBHQ1ZcuiHLyxxky8IE98",
    "/", "edu.tinkoff.ru"));
handler.CookieContainer = cookies;
var httpClient = new HttpClient(handler);

var jsonContent = new StringContent(serialize, Encoding.Default, "application/json");
var postAsync = await httpClient.PostAsync("https://edu.tinkoff.ru/api/v3/exam/task/5685/answer/16782",
    jsonContent);
postAsync.EnsureSuccessStatusCode();

public class Result
{
    public string[] values { get; set; }
    public int lang_id { get; set; } = 10;
}