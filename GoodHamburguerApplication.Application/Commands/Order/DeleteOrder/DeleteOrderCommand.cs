using MediatR;

namespace GoodHamburguerApplication.Application.Commands.Order.SendOrder
{
    public class DeleteOrderCommand : IRequest<bool>
    {
        public int Id{ get; set; }

        public DeleteOrderCommand(int id)
        {
            Id = id;
        }
    }
}
