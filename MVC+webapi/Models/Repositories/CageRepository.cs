using Microsoft.EntityFrameworkCore;
using MVC_webapi.Infrastructure;
using MVC_webapi.Models.Entities;
using MVC_webapi.Models.RepoInterfaces;

namespace MVC_webapi.Models.Repositories
{
    public class CageRepository : ICageRepository
    {
        private readonly ApplicationDbContext _context;
        public CageRepository(ApplicationDbContext context)
        {
            _context = context;    
        }

        public async Task CreateCage(short size)
        {
            var cage = new Cages(size);
            await _context.AddAsync(cage);
            await _context.SaveChangesAsync();
        }

        public async  Task<IEnumerable<Birds>> getAllInCage(Guid CageId)
        {
            var cage = await _context.Cages.FirstOrDefaultAsync(c => c.Id == CageId); 
            if (cage is null) { return  Enumerable.Empty<Birds>(); }
            return cage.getAllInCage();
        }

        public async Task PutInCage(Guid BirdId,Guid CageID)
        {
            var bird = await _context.Birds.FirstOrDefaultAsync(b => b.Id == BirdId);
            if (bird is not null)
            {
                var cage = await _context.Cages.FirstOrDefaultAsync(c => c.Id == CageID);
                if (cage is not null)
                {
                    cage.PutInCage(bird);
                }
            }
        }
    }
}
