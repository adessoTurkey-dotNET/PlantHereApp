using PlantHere.Application.Interfaces;

namespace PlantHere.Application.CQRS.Product.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id);

            await _unitOfWork.ProductRepository.RemoveAsync(product);

            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
