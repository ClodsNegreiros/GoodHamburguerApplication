using GoodHamburguerApplication.Application.Requests;
using GoodHamburguerApplication.Application.Responses.Order;

namespace GoodHamburguerApplication.Application.Interfaces.Order
{
    public interface IUpdateOrderUseCase
    {
        Task<bool> Execute(int orderId, UpdateOrderRequest request);
    }
}
