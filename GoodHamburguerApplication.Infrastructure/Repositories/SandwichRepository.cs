using GoodHamburguerApplication.Domain.Entities;
using GoodHamburguerApplication.Domain.Interfaces;
using GoodHamburguerApplication.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburguerApplication.Infrastructure.Repositories
{
    public class SandwichRepository : ISandiwchRepository
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
    }
}
