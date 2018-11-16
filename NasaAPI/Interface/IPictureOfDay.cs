using NasaAPI.Entities;
using System.Threading.Tasks;

namespace NasaAPI.Interface
{
    public interface IPictureOfDay
    {
        Task<PictureOfDay> GetPictureOfDay();
    }
}
