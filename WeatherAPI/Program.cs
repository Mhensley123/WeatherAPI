using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;


namespace OpenWeatherMapAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            Console.WriteLine("Please enter your API key:");
            //string api_Key = "2d93fb15c26257b682cf08ebae8d29a5";
            string? api_Key = Console.ReadLine();
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter the city name: ");
                string? city_name = Console.ReadLine();
                string weatherURL = $"http://api.openweathermap.org/data/2.5/weather?q={city_name}&appid={api_Key}&units=imperial";

                var response = client.GetStringAsync(weatherURL).Result;
                string formattedResponse = JObject.Parse(response).GetValue("main").ToString();
                Console.WriteLine(formattedResponse);
                Console.WriteLine();
                Console.WriteLine("Would you like to know the weather of a different city?");
                var userInput = Console.ReadLine();
                Console.WriteLine();
                if (userInput.ToLower() == "no")
                {
                    break;
                }

            }
        }
    }
}
