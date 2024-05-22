using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_information_app.Data
{
    /// <summary>
    /// 天気の情報全般のクラス
    /// </summary>
    [Serializable]
    public class WeatherInformation
    {
        public Dictionary<string, double>? coord {  get; set; }

        public IList<Dictionary<string, dynamic>>? weather {  get; set; }        
        public string? infoBase {  get; set; }

        public Dictionary<string, double>? main {  get; set; }

        public double visibility;

        public Dictionary<string, double>? wind { get; set; }

       public Dictionary<string, double>? rain { get; set; }

        public Dictionary<string, double>? clouds { get; set; }

        public double dt;

        public Dictionary<string,object>? sys { get; set; }

        public int timezone;

        public double id;

        public string? name;

        public int cod;

    }
}
