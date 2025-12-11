using MVC_webapi.Models.Entities;

namespace MVC_webapi.Models.RepoInterfaces
{
    public interface ICageRepository
    {
        Task<IEnumerable<Birds>> getAllInCage(Guid CageId);

        Task PutInCage(Guid BirdId,Guid CageId);
        Task CreateCage(short size);
    }
}
