using PlantHere.Application.Interfaces;

namespace PlantHere.Application.CQRS.Category.Cammands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryCommandResult>, IRequestPreProcessor<UpdateCategoryCommand>
    {

        private readonly IUnitOfWork _unitOfWork;

        private readonly IEnumerable<IValidator<UpdateCategoryCommand>> _validators;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IEnumerable<IValidator<UpdateCategoryCommand>> validators)
        {
            _unitOfWork = unitOfWork;
            _validators = validators;
        }

        public async Task<UpdateCategoryCommandResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id);

            category.NameEn = request.NameEn;
            category.NameTr = request.NameTr;

            await _unitOfWork.CategoryRepository.UpdateAsync(category);
            await _unitOfWork.CommitAsync();
            return new UpdateCategoryCommandResult();
        }

        public async Task Process(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await new CustomValidationResult<UpdateCategoryCommand>(_validators).IsValid(request, cancellationToken);

            if (result != null) throw result;

            await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id);
        }
    }
}
