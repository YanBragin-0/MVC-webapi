using Microsoft.EntityFrameworkCore;
using MVC_webapi.Infrastructure;
using MVC_webapi.Models.Entities;
using MVC_webapi.Models.RepoInterfaces;

namespace MVC_webapi.Models.Repositories
{
    public class BirdsRepository : IBirdsRepository
    {
        private readonly ApplicationDbContext _context;
        public BirdsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateBird(Birds newBird)
        {
            await _context.Birds.AddAsync(newBird);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Birds>> GetAll()
        {
            var result = await _context.Birds.ToListAsync();
            return result;
        }

        public async Task<Birds> getById(Guid Id)
        {
            var result = await _context.Birds.FirstOrDefaultAsync(b => b.Id == Id);
            return result;
        }
    }
}
