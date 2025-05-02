using GoodHamburguerApplication.Domain.Entities;

namespace GoodHamburguerApplication.Domain.Interfaces
{
    public interface IExtraRepository
    {
        Task<Extra> GetByIdAsync(int id);
        Task<List<Extra>> GetExtrasAsync();
    }
}
