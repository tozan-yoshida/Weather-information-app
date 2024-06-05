using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Weather_information_app.Data
{
    public class WeatherInformationForDB
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("Id")]
        public int Id { get; set; }

        [MaxLength(100)]
        [Column("Weather")]
        public string? Weather {  get; set; }

        [MaxLength(100)]
        [Column("City")]
        public string? City { get; set; }

        [Column("Temp")]
        public int Temp {  get; set; }

        [Column("MaxTemp")]
        public int MaxTemp { get; set; }

        [Column("MinTemp")]
        public int MinTemp { get; set; }

        [Column("DateTime")]
        public string? DateTime { get; set; }

        [Column("ImageId")]
        public string? ImageId {  get; set; }
    }
}
