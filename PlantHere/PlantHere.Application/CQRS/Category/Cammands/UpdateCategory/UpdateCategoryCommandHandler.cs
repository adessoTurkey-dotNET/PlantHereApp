using Microsoft.AspNetCore.Http;

namespace PlantHere.Application.CQRS.Category.Cammands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CustomResult<UpdateCategoryCommandResult>>, IRequestPreProcessor<UpdateCategoryCommand>
    {
        private readonly ICategoryService _categoryService;

        private readonly IMapper _mapper;

        private readonly IEnumerable<IValidator<UpdateCategoryCommand>> _validators;

        public UpdateCategoryCommandHandler(ICategoryService categoryService, IMapper mapper, IEnumerable<IValidator<UpdateCategoryCommand>> validators)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _validators = validators;
        }

        public async Task<CustomResult<UpdateCategoryCommandResult>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryService.GetByIdAsync(request.Id);

            category.NameEn = request.NameEn;
            category.NameTr = request.NameTr;

            await _categoryService.UpdateAsync(category);

            return CustomResult<UpdateCategoryCommandResult>.Success(StatusCodes.Status204NoContent, new UpdateCategoryCommandResult());
        }

        public async Task Process(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await new CustomValidationResult<UpdateCategoryCommand>(_validators).IsValid(request, cancellationToken);

            if (result != null) throw result;

            await _categoryService.GetByIdAsync(request.Id);
        }
    }
}
