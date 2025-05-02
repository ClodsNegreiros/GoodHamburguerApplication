using GoodHamburguerApplication.Domain.Entities;

namespace GoodHamburguerApplication.Domain.Interfaces
{
    public interface IExtraRepository
    {
        Task<List<Extra>> GetExtrasAsync();
    }
}
