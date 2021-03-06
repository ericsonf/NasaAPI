using NasaAPI.Entities;
using NasaAPI.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace NasaAPI.Services
{
    public class PictureOfDayService : IPictureOfDay
    {
        public async Task<PictureOfDay> GetPictureOfDay()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync("https://api.nasa.gov/planetary/apod?api_key=<SUA_NASA_KEY>");
            var pictureOfDay = new PictureOfDay();

            if (response.IsSuccessStatusCode)
                pictureOfDay =
                    await JsonSerializer.DeserializeAsync<PictureOfDay>(await response.Content.ReadAsStreamAsync());

            return pictureOfDay;
        }
    }
}