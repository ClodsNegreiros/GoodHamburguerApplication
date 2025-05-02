using GoodHamburguerApplication.Domain.Entities;

namespace GoodHamburguerApplication.Domain.Interfaces
{
    public interface ISandwichRepository
    {
        Task<List<Sandwich>> GetSandiwchesAsync();
    }
}
