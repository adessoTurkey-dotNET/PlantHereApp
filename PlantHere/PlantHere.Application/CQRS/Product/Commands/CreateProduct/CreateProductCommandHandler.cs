using PlantHere.Application.Interfaces;
using ModelProduct = PlantHere.Domain.Aggregate.CategoryAggregate.Product;


namespace PlantHere.Application.CQRS.Product.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductCommandResult>, IRequestPreProcessor<CreateProductCommand>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IEnumerable<IValidator<CreateProductCommand>> _validators;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IEnumerable<IValidator<CreateProductCommand>> validators, IMapper mapper,IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; 
            _validators = validators;
            _mapper = mapper;
        }

        public async Task<CreateProductCommandResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.ProductRepository.AddAsync(_mapper.Map<ModelProduct>(request));
            
            await _unitOfWork.CommitAsync();
            
            return new CreateProductCommandResult();
        }

        public async Task Process(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var result = await new CustomValidationResult<CreateProductCommand>(_validators).IsValid(request, cancellationToken);

            if (result != null) throw result;

            await _unitOfWork.CategoryRepository.GetByIdAsync(request.CategoryId);
        }

    }
}
