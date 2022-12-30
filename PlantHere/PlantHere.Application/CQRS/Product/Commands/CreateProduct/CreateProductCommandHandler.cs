using ModelProduct = PlantHere.Domain.Aggregate.CategoryAggregate.Product;


namespace PlantHere.Application.CQRS.Product.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CustomResult<CreateProductCommandResult>>, IRequestPreProcessor<CreateProductCommand>
    {
        private readonly IProductService _productService;

        private readonly ICategoryService _categoryService;

        private readonly IEnumerable<IValidator<CreateProductCommand>> _validators;

        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductService productService, ICategoryService categoryService, IEnumerable<IValidator<CreateProductCommand>> validators, IMapper mapper)
        {
            _productService = productService;
            _validators = validators;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        public async Task<CustomResult<CreateProductCommandResult>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productService.AddAsync(_mapper.Map<ModelProduct>(request));

            return CustomResult<CreateProductCommandResult>.Success(201, _mapper.Map<CreateProductCommandResult>(product));
        }

        public async Task Process(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var result = await new CustomValidationResult<CreateProductCommand>(_validators).IsValid(request, cancellationToken);

            if (result != null) throw result;

            await _categoryService.GetByIdAsync(request.CategoryId);
        }

    }
}
