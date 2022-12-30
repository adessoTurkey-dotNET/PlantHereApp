﻿namespace PlantHere.Application.CQRS.Category.Cammands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CustomResult<CreateCategoryCommandResult>>
    {
        public string? NameTr { get; set; }

        public string? NameEn { get; set; }

    }
}