
using GoodHamburguerApplication.Domain.Entities;

namespace GoodHamburguerApplication.Application.Interfaces.Order
{
    public interface IGetExtrasUseCase
    {
        Task<List<Extra>> Execute();
    }
}
