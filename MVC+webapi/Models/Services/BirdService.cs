using MVC_webapi.Models.Entities;
using MVC_webapi.Models.RepoInterfaces;
using MVC_webapi.Models.ServiceInterfaces;

namespace MVC_webapi.Models.Services
{
    public class BirdService : IBirdService
    {
        private readonly IBirdsRepository _repository;
        public BirdService(IBirdsRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(string name, string description, string imgUrl)
        {
            var bird = new Birds(name,description,imgUrl);
            await _repository.CreateBird(bird);
        }

        public Task<IEnumerable<Birds>> getAll() => _repository.GetAll();


        public async Task<Birds> getBuId(Guid BirdID) => await _repository.getById(BirdID);

    }
}
