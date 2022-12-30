namespace PlantHere.Application.CQRS.Product.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<Unit>
    {
        public DeleteProductCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
