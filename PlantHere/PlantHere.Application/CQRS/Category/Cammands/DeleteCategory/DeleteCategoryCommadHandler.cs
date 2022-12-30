using Microsoft.AspNetCore.Http;

namespace PlantHere.Application.CQRS.Category.Cammands.DeleteCategory
{
    public class DeleteCategoryCommadHandler : IRequestHandler<DeleteCategoryCommand, CustomResult<DeleteCategoryCommandResult>>, IRequestPreProcessor<DeleteCategoryCommand>
    {
        private readonly ICategoryService _categoryService;

        private readonly IMapper _mapper;

        private readonly IEnumerable<IValidator<DeleteCategoryCommand>> _validators;

        public DeleteCategoryCommadHandler(ICategoryService categoryService, IMapper mapper, IEnumerable<IValidator<DeleteCategoryCommand>> validators)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _validators = validators;
        }

        public async Task<CustomResult<DeleteCategoryCommandResult>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryService.GetByIdAsync(request.Id);

            await _categoryService.RemoveAsync(category);

            return CustomResult<DeleteCategoryCommandResult>.Success(StatusCodes.Status204NoContent);
        }

        public async Task Process(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await new CustomValidationResult<DeleteCategoryCommand>(_validators).IsValid(request, cancellationToken);

            if (result != null) throw result;

            await _categoryService.GetByIdAsync(request.Id);
        }
    }
}
