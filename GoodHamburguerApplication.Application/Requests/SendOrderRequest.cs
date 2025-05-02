using GoodHamburguerApplication.Domain.Entities;

namespace GoodHamburguerApplication.Application.Requests
{
    public class SendOrderRequest
    {
        public int SandwichId { get; set; }
        public List<int> ExtraIds { get; set; }
    }
}
