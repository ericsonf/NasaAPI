using NasaAPI.Entities;
using NasaAPI.Interface;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NasaAPI.Services
{
    public class ObjectService : IObjectService
    {
        public byte[] SetObjectCache(object obj)
        {
            var binaryFormatter = new BinaryFormatter();
            using (var memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, obj);
                return memoryStream.ToArray();
            }
        }

        public PictureOfDay GetObjectCache(byte[] objArray)
        {
            var binaryFormatter = new BinaryFormatter();
            using (var memoryStream = new MemoryStream(objArray))
            {
                return binaryFormatter.Deserialize(memoryStream) as PictureOfDay;
            }
        }
    }
}
