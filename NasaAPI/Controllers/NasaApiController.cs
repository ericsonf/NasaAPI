using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using NasaAPI.Entities;
using NasaAPI.Interfaces;

namespace NasaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NasaApiController : ControllerBase
    {
        private readonly IPictureOfDay _apiService;
        private readonly IObjectService _objService;
        private readonly IDistributedCache _distributedCache;
        const string key = "pictureofday";

        public NasaApiController(IPictureOfDay apiService, IObjectService objService, IDistributedCache distributedCache)
        {
            _apiService = apiService;
            _objService = objService;
            _distributedCache = distributedCache;
        }

        // GET api/NasaApi
        [HttpGet]
        public async Task<PictureOfDay> GetPictureOfDay()
        {
            var cache = await _distributedCache.GetAsync(key);

            if (cache != null)
                return _objService.GetObjectCache(cache);
            else
            {
                var cacheExpiration = (DateTime.Today.AddDays(1).AddTicks(-1) - DateTime.Now).TotalSeconds;
                var pictureOfDay = await _apiService.GetPictureOfDay();
                await _distributedCache.SetAsync(key, _objService.SetObjectCache(pictureOfDay),
                    new DistributedCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(cacheExpiration)));
                return pictureOfDay;
            } 
        }
    }
}
