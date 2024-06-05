using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Weather_information_app.Data
{
    public static class RestService
    {
       
        private static readonly string BaseAddress1 = "https://api.openweathermap.org/data/2.5/weather?q=";
        private static readonly string BaseAddress2 = "&appid=3bd246bbaa5667a22974b88af896fe4d&lang=ja&units=metric";
        static HttpClient? client;

        private static HttpClient GetClient()
        {
            if(client != null) 
                return client;

            client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            return client;
        }

        public static async Task<WeatherInformationAll> GetAll(string city, string country)
        {
            if(Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return new WeatherInformationAll();

            try
            {
                client = GetClient();
                string result = await client.GetStringAsync($@"{BaseAddress1}{city},{country}{BaseAddress2}");
                WeatherInformationAll all = JsonSerializer.Deserialize<WeatherInformationAll>(result, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                })!;

                return all;
            }
            catch
            {
                return null!;
            }
        }
    }
}
