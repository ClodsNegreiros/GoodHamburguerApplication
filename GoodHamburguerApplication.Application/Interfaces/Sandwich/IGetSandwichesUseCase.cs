
using GoodHamburguerApplication.Domain.Entities;

namespace GoodHamburguerApplication.Application.Interfaces.Order
{
    public interface IGetSandwichesUseCase
    {
        Task<List<Sandwich>> Execute();
    }
}
