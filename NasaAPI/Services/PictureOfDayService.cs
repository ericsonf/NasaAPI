﻿using NasaAPI.Entities;
using NasaAPI.Interface;
using System.Net.Http;
using System.Threading.Tasks;

namespace NasaAPI.Services
{
    public class PictureOfDayService : IPictureOfDay
    {
        public async Task<PictureOfDay> GetPictureOfDay()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://api.nasa.gov/planetary/apod?api_key=<SUA_NASA_API_KEY>");
                var pictureOfDay = new PictureOfDay();

                if (response.IsSuccessStatusCode)
                {
                    pictureOfDay = await response.Content.ReadAsAsync<PictureOfDay>();
                }

                return pictureOfDay;
            }
        }
    }
}