namespace PlantHere.Application.CQRS.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>, IRequestPreProcessor<UpdateProductCommand>
    {
        private readonly IProductService _productService;

        private readonly ICategoryService _categoryService;

        private readonly IEnumerable<IValidator<UpdateProductCommand>> _validators;

        public UpdateProductCommandHandler(IProductService productService, ICategoryService categoryService, IEnumerable<IValidator<UpdateProductCommand>> validators)
        {
            _productService = productService;
            _categoryService = categoryService;
            _validators = validators;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productService.GetByIdAsync(request.Id);

            product.Name = request.Name;
            product.Stock = request.Stock;
            product.Price = request.Price;
            product.UpdatedDate = DateTime.Now;
            product.Description = request.Description;
            await _productService.UpdateAsync(product);
            return Unit.Value;
        }

        public async Task Process(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var result = await new CustomValidationResult<UpdateProductCommand>(_validators).IsValid(request, cancellationToken);

            if (result != null) throw result;

            await _categoryService.GetByIdAsync(request.CategoryId);

        }

    }
}
