using GoodHamburguerApplication.Domain.Entities;

namespace GoodHamburguerApplication.Domain.Interfaces
{
    public interface ISandiwchRepository
    {
        Task<List<Sandwich>> GetSandiwchesAsync();
    }
}
