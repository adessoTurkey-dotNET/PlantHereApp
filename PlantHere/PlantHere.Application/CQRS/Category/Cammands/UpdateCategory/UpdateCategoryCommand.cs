namespace PlantHere.Application.CQRS.Category.Cammands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<CustomResult<UpdateCategoryCommandResult>>
    {
        public int Id { get; set; }

        public string NameTr { get; set; }

        public string NameEn { get; set; }
    }
}
