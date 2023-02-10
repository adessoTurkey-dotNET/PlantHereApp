using PlantHere.Application.CQRS.Base;
using PlantHere.Application.Interfaces.Commands;

namespace PlantHere.Application.CQRS.Order.Commands.DeleteOrder
{
    public class DeleteOrderCommand : CommandBase<Unit>, ICommandRemoveCache
    {
        public DeleteOrderCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
