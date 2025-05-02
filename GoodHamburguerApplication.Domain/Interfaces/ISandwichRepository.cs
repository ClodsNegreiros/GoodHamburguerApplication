using GoodHamburguerApplication.Domain.Entities;

namespace GoodHamburguerApplication.Domain.Interfaces
{
    public interface ISandwichRepository
    {
        Task<Sandwich> GetByIdAsync(int id);
        Task<List<Sandwich>> GetSandiwchesAsync();
    }
}
