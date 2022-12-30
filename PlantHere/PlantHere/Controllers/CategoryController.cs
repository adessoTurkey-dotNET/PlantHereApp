
using PlantHere.Application.CQRS.Category.Cammands.CreateCategory;
using PlantHere.Application.CQRS.Category.Cammands.DeleteCategory;
using PlantHere.Application.CQRS.Category.Cammands.UpdateCategory;
using PlantHere.Application.CQRS.Category.Queries.GetAllCategories;

namespace PlantHere.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : CustomBaseController
    {

        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _mediator.Send(new GetAllCategoriesQuery());
            return CreateActionResult(CustomResult<IEnumerable<GetAllCategoriesQueryResult>>.Success(200, categories));
        }

        [Authorize(Roles = "superadmin")]
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand createCategoryCommand)
        {
            return CreateActionResult(await _mediator.Send(createCategoryCommand));
        }

        [Authorize(Roles = "superadmin")]
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand updateCategoryCommand)
        {
            return CreateActionResult(await _mediator.Send(updateCategoryCommand));
        }

        [Authorize(Roles = "superadmin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(DeleteCategoryCommand deleteCategoryCommand)
        {
            return CreateActionResult(await _mediator.Send(deleteCategoryCommand));
        }

    }
}
