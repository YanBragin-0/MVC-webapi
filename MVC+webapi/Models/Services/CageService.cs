using MVC_webapi.Models.Entities;
using MVC_webapi.Models.RepoInterfaces;
using MVC_webapi.Models.ServiceInterfaces;

namespace MVC_webapi.Models.Services
{
    public class CageService : ICageService
    {
        private readonly ICageRepository _repository;
        public CageService(ICageRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(short size)
        {
            await _repository.CreateCage(size);
        }

        public async Task<IEnumerable<Birds>> getAllInCgae(Guid CageID)
        {
            return await _repository.getAllInCage(CageID);
        }

        public async Task PutInCagae(Guid BirdId, Guid CageId)
        {
            await _repository.PutInCage(BirdId, CageId);
        }
    }
}
