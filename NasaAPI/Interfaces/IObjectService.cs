using NasaAPI.Entities;

namespace NasaAPI.Interfaces
{
    public interface IObjectService
    {
        byte[] SetObjectCache(object obj);
        PictureOfDay GetObjectCache(byte[] objArray);
    }
}