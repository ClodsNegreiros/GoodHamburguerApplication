using GoodHamburguerApplication.Domain.Entities;
using GoodHamburguerApplication.Domain.Interfaces;
using GoodHamburguerApplication.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburguerApplication.Infrastructure.Repositories
{
    public class ExtraRepository : IExtraRepository
    {
        private readonly ApplicationDbContext _context;

        public ExtraRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<List<Extra>> GetExtrasAsync()
        {
            return await _context.Extras.ToListAsync();
        }
        
        public async Task<Extra> GetByIdAsync(int id)
        {
            return await _context.Extras
                .SingleOrDefaultAsync(extra => extra.Id == id);
        }
    }
}