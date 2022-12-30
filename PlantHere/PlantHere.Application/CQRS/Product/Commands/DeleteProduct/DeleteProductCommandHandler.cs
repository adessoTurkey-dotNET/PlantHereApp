namespace PlantHere.Application.CQRS.Product.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {

        private readonly IProductService _productService;

        public DeleteProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productService.GetByIdAsync(request.Id);

            await _productService.RemoveAsync(product);

            return Unit.Value;
        }
    }
}
