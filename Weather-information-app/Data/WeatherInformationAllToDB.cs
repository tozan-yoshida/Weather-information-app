using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_information_app.Data
{
    public static class WeatherInformationAllToDB
    {
        public static WeatherInformationForDB Convert(WeatherInformationAll weatherInformationAll)
        {
            string weather = weatherInformationAll.weather![0]["description"].ToString();
            string city = weatherInformationAll.name!;
            int temp = (int)weatherInformationAll.main!["temp"];
            int maxTemp = (int)weatherInformationAll.main["temp_max"];
            int minTemp = (int)weatherInformationAll.main["temp_min"];
            string imageId = weatherInformationAll.weather[0]["icon"].ToString();
            var forDB = new WeatherInformationForDB
            {
                Weather = weather,
                City = city,
                Temp = temp,
                MaxTemp = maxTemp,
                MinTemp = minTemp,
                DateTime = DateTime.Now.ToString(@$"M/d(ddd) H:mm"),
                ImageId = imageId,
            };
            return forDB;
        }
    }
}
