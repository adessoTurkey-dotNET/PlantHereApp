namespace PlantHere.Application.CQRS.Category.Cammands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<DeleteCategoryCommandResult>
    {
        public int Id { get; set; }
    }
}
