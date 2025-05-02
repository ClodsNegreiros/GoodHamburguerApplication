namespace GoodHamburguerApplication.Application.Requests
{
    public class UpdateOrderRequest
    {
        public int SandwichId { get; set; }
        public List<int>? ExtraIds { get; set; }
    }
}
