using System.Net;
using System.Text;
using System.Text.Json;

var result = new Result();
result.values = new[] { File.ReadAllText("Solution.xxx") };
var serialize = JsonSerializer.Serialize(result);
using var handler = new HttpClientHandler();

var cookies = new CookieContainer();
cookies.Add(new Cookie("token",
    "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpZCI6Mzk2NzExLCJtYXN0ZXJfaWQiOm51bGwsInJvbGVzIjpbXSwiZXhwIjoxNjcwMDExMDMyLCJpbnRyYW5ldCI6ZmFsc2UsImF1dGhfdHlwZSI6ImV4dCIsInRhZ3MiOlsidGlua29mZl9lZHVjYXRpb24iXX0.Dd0MPCoq6tDZxIJGO_oydlNYJ25N1495k8Zw0K1LTes",
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