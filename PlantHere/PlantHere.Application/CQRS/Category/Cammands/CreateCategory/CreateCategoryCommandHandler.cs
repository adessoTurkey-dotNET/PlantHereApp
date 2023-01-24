using PlantHere.Application.Interfaces;
using ModelCategory = PlantHere.Domain.Aggregate.CategoryAggregate.Category;

namespace PlantHere.Application.CQRS.Category.Cammands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResult>, IRequestPreProcessor<CreateCategoryCommand>
    {

        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IEnumerable<IValidator<CreateCategoryCommand>> _validators;

        public CreateCategoryCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IEnumerable<IValidator<CreateCategoryCommand>> validators)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _validators = validators;
        }

        public async Task<CreateCategoryCommandResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.CategoryRepository.AddAsync(_mapper.Map<ModelCategory>(request));
            await _unitOfWork.CommitAsync();
            return new CreateCategoryCommandResult();
        }

        public async Task Process(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await new CustomValidationResult<CreateCategoryCommand>(_validators).IsValid(request, cancellationToken);

            if (result != null) throw result;

        }
    }
}
