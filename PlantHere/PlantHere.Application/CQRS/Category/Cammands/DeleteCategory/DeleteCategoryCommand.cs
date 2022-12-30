namespace PlantHere.Application.CQRS.Category.Cammands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<CustomResult<DeleteCategoryCommandResult>>
    {
        public int Id { get; set; }
    }
}
