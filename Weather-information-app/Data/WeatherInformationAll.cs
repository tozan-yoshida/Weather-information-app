using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Weather_information_app.Data
{

    /// <summary>
    /// 天気の情報全般のクラス
    /// </summary>
    [Serializable]
    public class WeatherInformationAll
    {
        public Dictionary<string, double>? coord {  get; set; }

        public IList<Dictionary<string, dynamic>>? weather {  get; set; }        
        public string? @base {  get; set; }

        public Dictionary<string, double>? main {  get; set; }

        public double visibility {  get; set; }

        public Dictionary<string, double>? wind { get; set; }

        public Dictionary<string, double>? clouds { get; set; }

        public double dt {  get; set; }

        public Dictionary<string,object>? sys { get; set; }

        public int timezone {  get; set; }

        public double id {  get; set; }

        public string? name {  get; set; }

        public int cod {  get; set; }

    }
}
