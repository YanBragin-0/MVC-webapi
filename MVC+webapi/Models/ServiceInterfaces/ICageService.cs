using MVC_webapi.Models.Entities;

namespace MVC_webapi.Models.ServiceInterfaces
{
    public interface ICageService
    {
        Task<IEnumerable<Birds>> getAllInCgae(Guid CageID);
        Task PutInCagae(Guid BirdId, Guid CageId);
        Task Create (short size);
    }
}
