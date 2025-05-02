
namespace GoodHamburguerApplication.Application.Interfaces.Order
{
    public interface IGetOrdersUseCase
    {
        Task<List<Domain.Entities.Order>> Execute();
    }
}
