using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_information_app.Data
{
    public class RestService
    {
        public string lon { get; set; } // 緯度
        public string lat { get; set; } // 経度
        private string url;
        static HttpClient client;

        public RestService(string lon, string lat) 
        {
            this.lon = lon;
            this.lat = lat;
            url = @$"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid=3bd246bbaa5667a22974b88af896fe4d&lang=ja&units=metric";
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        
    }
}
