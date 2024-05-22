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
    class WeatherInformation
    {
        public string weather {  get; set; }        // 天気の情報（晴れ、曇り等）
        public string weatherIcon {  get; set; }    // 天気のアイコン

        public string temp { get; set; }            // 現在気温
        public string tempMax {  get; set; }        // 最高気温
        public string tempMin { get; set; }         // 最低気温

        public string city {  get; set; }           // 位置情報

        public DateTime date {  get; set; }         // 日付

    }
}
