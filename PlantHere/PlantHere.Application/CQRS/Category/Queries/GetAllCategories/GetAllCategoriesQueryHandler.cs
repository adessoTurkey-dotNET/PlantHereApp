namespace PlantHere.Application.CQRS.Category.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<GetAllCategoriesQueryResult>>
    {
        private readonly ICategoryService _categoryService;

        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(ICategoryService categoryService, IMapper mapper)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        public async Task<IEnumerable<GetAllCategoriesQueryResult>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryService.GetAllAsync();
            return _mapper.Map<IEnumerable<GetAllCategoriesQueryResult>>(categories);
        }
    }
}
