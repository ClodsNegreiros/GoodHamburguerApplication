using GoodHamburguerApplication.Domain.Entities;

namespace GoodHamburguerApplication.Application.Responses.Order
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Discount { get; set; }
        public DateTime CreatedAt { get; set; }
        public int SandwichId { get; set; }
        public Sandwich? Sandwich { get; set; }
        public List<Extra> Extras { get; set; }
    }
}
