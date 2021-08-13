using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Linq;
using Serilog;

namespace Api
{
  class Api
  {
    public static int GetRandomNumber(int min, int max)
    {
        int random_number = new Random().Next(min, max);
        return random_number;
    }

    public static string SendRequest(string url, string uri)
    {   
      HttpClient client = new HttpClient();
      client.BaseAddress = new Uri(url);
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
      try {
        HttpResponseMessage response = client.GetAsync(uri).Result;
        string responseBody = response.Content.ReadAsStringAsync().Result;
        return responseBody;
      }
      catch (Exception ex) {
        Log.Error("Exception Raised! - {ex}", ex);
        return "Failure";
      }
    }
    public class FactResponse
    {
        public string Fact {get;set;}
    }

    static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
          .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
          .CreateLogger();

        string URL = "https://dog-facts-api.herokuapp.com/api/v1/resources/dogs";
        string URI = "?index=";
        int min = 1, max = 100;
        int random_num = GetRandomNumber(min, max);
        Log.Information("Random Number between {min} and {max} is: {random_num}", min, max, random_num);

        string fullURI = URI + random_num;
        string result = SendRequest(URL, fullURI);

        var options = new JsonSerializerOptions
        {
          PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        var factResponse = JsonSerializer.Deserialize<FactResponse[]>(result, options);
        var facts = factResponse.Select(x => x.Fact);

        foreach(var fact in facts)
        {
           Log.Information(fact);
        }
    }
  }
}