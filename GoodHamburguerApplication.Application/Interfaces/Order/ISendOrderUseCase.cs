using GoodHamburguerApplication.Application.Requests;
using GoodHamburguerApplication.Application.Responses.Order;

namespace GoodHamburguerApplication.Application.Interfaces.Order
{
    public interface ISendOrderUseCase
    {
        Task<OrderResponse> Execute(SendOrderRequest request);
    }
}
