
// Interface
const Interface = require("es6-interface");
const {ICategoryService} = require('../../../Core/PlantHere.Aplication/Interfaces/Services/ICategoryService')

// Results
const {CustomResult} = require("../../../Core/PlantHere.Aplication/RequestResponseModels/Results/CustomResult");

// RequestResponseModels
// GetCategories
const {GetCategoriesQuery} = require("../../../Core/PlantHere.Aplication/RequestResponseModels/Category/Queries/GetCategories/GetCategoriesQuery")
const {GetCategoriesQueryResult} = require("../../../Core/PlantHere.Aplication/RequestResponseModels/Category/Queries/GetCategories/GetCategoriesQueryResult")

// GetCategoryById 
const {GetCategoryByIdQuery} = require("../../../Core/PlantHere.Aplication/RequestResponseModels/Category/Queries/GetCategoryById/GetCategoryByIdQuery")
const {GetCategoryByIdQueryResult} = require("../../../Core/PlantHere.Aplication/RequestResponseModels/Category/Queries/GetCategoryById/GetCategoryByIdQueryResult")

const {CreateCategoryCommandResult} = require("../../../Core/PlantHere.Aplication/RequestResponseModels/Category/Command/CreateCategory/CreateCategoryCommandResult")
const {UpdateCategoryCommandResult} = require("../../../Core/PlantHere.Aplication/RequestResponseModels/Category/Command/UpdateCategory/UpdateCategoryCommandResult")
const {DeleteCategoryCommandResult} = require("../../../Core/PlantHere.Aplication/RequestResponseModels/Category/Command/DeleteCategory/DeleteCategoryCommandResult")


// Helper

const Guid = require("./GuidService")

class CategoryService extends Interface(ICategoryService)
{
    constructor(repository) {
        super()
        this.repository = repository;
    }

    async getCategories() {
        const categories = await this.repository.getCategories(new GetCategoriesQuery())
        return CustomResult.Success(new GetCategoriesQueryResult(categories), null)
    }

    async getCategoryById(req) {
        return CustomResult.Success(new GetCategoryByIdQueryResult(await this.repository.getCategoryById(req.Id)))
    }

    async createCategory(req){
        return CustomResult.Success(new  CreateCategoryCommandResult(await this.repository.createCategory(req)))
    }

    async updateCategory(req){
        return CustomResult.Success(new UpdateCategoryCommandResult(await this.repository.updateCategory(req)))
    }

    async deleteCategory(req){
        return CustomResult.Success(new DeleteCategoryCommandResult(await this.repository.deleteCategory(req)))
    }
}

module.exports = { CategoryService }