

namespace GoodHamburguerApplication.Application.Interfaces.Order
{
    public interface IDeleteOrderUseCase
    {
        Task<bool> Execute(int id);
    }
}
