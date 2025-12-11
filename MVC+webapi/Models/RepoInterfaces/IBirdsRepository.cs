using MVC_webapi.Models.Entities;

namespace MVC_webapi.Models.RepoInterfaces
{
    public interface IBirdsRepository
    {
        Task<IEnumerable<Birds>> GetAll();
        Task<Birds> getById(Guid Id);
        Task CreateBird(Birds newBird);
    }
}
