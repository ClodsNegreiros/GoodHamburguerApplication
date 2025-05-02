using GoodHamburguerApplication.Domain.Entities;
using GoodHamburguerApplication.Domain.Interfaces;
using GoodHamburguerApplication.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburguerApplication.Infrastructure.Repositories
{
    public class SandwichRepository : ISandwichRepository
    {
        private readonly ApplicationDbContext _context;

        public SandwichRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<List<Sandwich>> GetSandiwchesAsync()
        {
            return await _context.Sandwiches.ToListAsync();
        }

        public async Task<Sandwich> GetByIdAsync(int id)
        {
            return await _context.Sandwiches
                .SingleOrDefaultAsync(sandwich => sandwich.Id == id);
        }
    }
}
