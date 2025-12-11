using MVC_webapi.Models.Entities;

namespace MVC_webapi.Models.ServiceInterfaces
{
    public interface IBirdService
    {
        Task Create(string name, string description,string imgUrl);
        Task<IEnumerable<Birds>> getAll();
        Task<Birds> getBuId(Guid BirdID);
    }
}
