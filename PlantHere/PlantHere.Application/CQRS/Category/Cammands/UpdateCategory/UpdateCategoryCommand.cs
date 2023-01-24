﻿namespace PlantHere.Application.CQRS.Category.Cammands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<UpdateCategoryCommandResult>
    {
        public int Id { get; set; }

        public string NameTr { get; set; }

        public string NameEn { get; set; }
    }
}
