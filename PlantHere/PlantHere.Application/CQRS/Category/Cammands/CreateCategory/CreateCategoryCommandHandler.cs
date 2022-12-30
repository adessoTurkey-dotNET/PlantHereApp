using Microsoft.AspNetCore.Http;
using ModelCategory = PlantHere.Domain.Aggregate.CategoryAggregate.Category;

namespace PlantHere.Application.CQRS.Category.Cammands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CustomResult<CreateCategoryCommandResult>>, IRequestPreProcessor<CreateCategoryCommand>
    {
        private readonly ICategoryService _categoryService;

        private readonly IMapper _mapper;

        private readonly IEnumerable<IValidator<CreateCategoryCommand>> _validators;

        public CreateCategoryCommandHandler(ICategoryService categoryService, IMapper mapper, IEnumerable<IValidator<CreateCategoryCommand>> validators)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _validators = validators;
        }

        public async Task<CustomResult<CreateCategoryCommandResult>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _categoryService.AddAsync(_mapper.Map<ModelCategory>(request));
            return CustomResult<CreateCategoryCommandResult>.Success(StatusCodes.Status200OK, new CreateCategoryCommandResult());
        }

        public async Task Process(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await new CustomValidationResult<CreateCategoryCommand>(_validators).IsValid(request, cancellationToken);

            if (result != null) throw result;

        }
    }
}
