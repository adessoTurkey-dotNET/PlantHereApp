using PlantHere.Application.Interfaces;

namespace PlantHere.Application.CQRS.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>, IRequestPreProcessor<UpdateProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IEnumerable<IValidator<UpdateProductCommand>> _validators;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IEnumerable<IValidator<UpdateProductCommand>> validators)
        {
            _unitOfWork = unitOfWork;
            _validators = validators;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id);

            product.Name = request.Name;
            product.Stock = request.Stock;
            product.Price = request.Price;
            product.UpdatedDate = DateTime.Now;
            product.Description = request.Description;

            await _unitOfWork.ProductRepository.UpdateAsync(product);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }

        public async Task Process(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var result = await new CustomValidationResult<UpdateProductCommand>(_validators).IsValid(request, cancellationToken);

            if (result != null) throw result;

            await _unitOfWork.CategoryRepository.GetByIdAsync(request.CategoryId);

        }

    }
}
