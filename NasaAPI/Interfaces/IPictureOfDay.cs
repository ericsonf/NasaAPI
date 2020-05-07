using NasaAPI.Entities;
using System.Threading.Tasks;

namespace NasaAPI.Interfaces
{
    public interface IPictureOfDay
    {
        Task<PictureOfDay> GetPictureOfDay();
    }
}