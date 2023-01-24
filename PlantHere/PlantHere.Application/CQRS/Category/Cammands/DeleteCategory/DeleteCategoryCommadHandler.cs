using PlantHere.Application.Interfaces;

namespace PlantHere.Application.CQRS.Category.Cammands.DeleteCategory
{
    public class DeleteCategoryCommadHandler : IRequestHandler<DeleteCategoryCommand, DeleteCategoryCommandResult>, IRequestPreProcessor<DeleteCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IEnumerable<IValidator<DeleteCategoryCommand>> _validators;

        public DeleteCategoryCommadHandler(IUnitOfWork unitOfWork,IEnumerable<IValidator<DeleteCategoryCommand>> validators)
        {
            _unitOfWork = unitOfWork;
            _validators = validators;
        }

        public async Task<DeleteCategoryCommandResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id);

            await _unitOfWork.CategoryRepository.RemoveAsync(category);

            await _unitOfWork.CommitAsync();

            return new DeleteCategoryCommandResult();
        }

        public async Task Process(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await new CustomValidationResult<DeleteCategoryCommand>(_validators).IsValid(request, cancellationToken);

            if (result != null) throw result;

            await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id);
        }
    }
}
