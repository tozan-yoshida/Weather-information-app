using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_information_app.Data;

namespace Weather_information_app
{
    public class LocalDBService
    {
        private const string DB_NAME = "weatherInformation.db3";
        private readonly SQLiteAsyncConnection _connection;

        public string StatusMessage {  get; set; }

        public LocalDBService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            _connection.CreateTableAsync<WeatherInformationForDB>().Wait();
            StatusMessage = "";
        }

        public async Task<List<WeatherInformationForDB>> GetWeatherInformations()
        {
            return await _connection.Table<WeatherInformationForDB>().OrderByDescending(x => x.Id).ToListAsync();
        }

        public async Task<WeatherInformationForDB> GetById(int id)
        {
            return await _connection.Table<WeatherInformationForDB>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Add(WeatherInformationForDB weatherInformationForDB)
        {
            try
            {
                await _connection.InsertAsync(weatherInformationForDB);
                StatusMessage = "success";
            }
            catch (Exception ex)
            {
                StatusMessage = ex.Message;
            }
        }

        public async Task Delete(WeatherInformationForDB weatherInformationForDB)
        {
            await _connection.DeleteAsync(weatherInformationForDB);
        }
 
    }
}
