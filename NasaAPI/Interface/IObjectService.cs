using System.Threading.Tasks;
using NasaAPI.Entities;

namespace NasaAPI.Interface
{
    public interface IObjectService
    {
        byte[] SetObjectCache(object obj);
        PictureOfDay GetObjectCache(byte[] objArray);
    }
}
