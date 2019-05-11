using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using NasaAPI.Entities;
using NasaAPI.Interface;

namespace NasaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NasaApiController : ControllerBase
    {
        private readonly IPictureOfDay _apiService;
        private readonly IObjectService _objService;
        private readonly IDistributedCache _distributedCache;

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
            //Nossa key que identifica o cache.
            var key = "pictureofday";
            //Tenta buscar o cache utilizando-se da key definida na linha anterior.
            var cache = await _distributedCache.GetAsync(key);

            //Se o cache for diferente de nulo, então chamamos o metodo para desserializar nosso objeto, uma vez que a interface IDistributedCache não faz isso pra nós.
            if (cache != null)
            {
                //Retorna os dados que estão no cache do Redis no Azure
                return _objService.GetObjectCache(cache);
            }
            else
            {
                //Cria uma data de expiração para o cache, com a data atual + 23:59:59
                var cacheExpiration = (DateTime.Today.AddDays(1).AddTicks(-1) - DateTime.Now).TotalSeconds;
                //Chama o metodo que recupera os dados da API da nasa.
                var pictureOfDay = await _apiService.GetPictureOfDay();
                //cria o nosso cache no Redis no Azure
                await _distributedCache.SetAsync(key, _objService.SetObjectCache(pictureOfDay), new DistributedCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(cacheExpiration)));
                //Retorna os dados da API da Nasa.
                return pictureOfDay;
            } 
        }
    }
}
