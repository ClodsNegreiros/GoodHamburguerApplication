using GoodHamburguerApplication.Domain.Entities;

namespace GoodHamburguerApplication.Domain.Interfaces
{
    public interface IOrderRepository
    {
        public Task<Order> SendOrderAsync(Order order);
        public Task<List<Order>> GetOrdersAsync();
        public Task<Order> UpdateOrderAsync(Order order);
        public Task<Order> DeleteOrderAsync(Order order);
    }
}
