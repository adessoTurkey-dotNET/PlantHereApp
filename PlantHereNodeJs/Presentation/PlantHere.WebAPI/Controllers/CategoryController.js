const { GetCategoriesQuery } = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Category/Queries/GetCategories/GetCategoriesQuery');
const { GetCategoryByIdQuery } = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Category/Queries/GetCategoryById/GetCategoryByIdQuery');
const { CreateCategoryCommand } = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Category/Command/CreateCategory/CreateCategoryCommand')
const { UpdateCategoryCommand } = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Category/Command/UpdateCategory/UpdateCategoryCommand')
const { DeleteCategoryCommand } = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Category/Command/DeleteCategory/DeleteCategoryCommand')


//  SERVICE

const CategoryService = require('../../../Core/PlantHere.Aplication/Services/CategoryService').CategoryService
const CategoryRepository = require('../../../Infratructure/PlantHere.Persistance/Repositories/CategoryRepository').CategoryRepository
const Guid = require('../../../Core/PlantHere.Aplication/Services/GuidService')

//Results
const {CustomResult} = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Results/CustomResult')

const categoryRepository = new CategoryRepository();
const service = new CategoryService(categoryRepository);


const getCategories = async (req, res) => {
    res.json(CustomResult.Success(await service.getCategories(new GetCategoriesQuery)))
}

const getCategoryById = async (req, res) => {
    res.json(CustomResult.Success(await service.getCategoryById(new GetCategoryByIdQuery(req.params.id))))
}

const createCategory = async (req, res) => {
    res.status(201).json(CustomResult.Success(await service.createCategory(new CreateCategoryCommand(req.body.nameEn, req.body.nameTr, Guid.createGuid()))))
}

const updateCategory = async (req, res) => {
    res.json(await service.updateCategory(CustomResult.Success(new UpdateCategoryCommand(req.body.id, req.body.nameEn, req.body.nameTr))))
}

const deleteCategory = async (req, res) => {
    res.json(await service.deleteCategory(CustomResult.Success(new DeleteCategoryCommand(req.body.id))))
}

module.exports = {
    getCategories,
    getCategoryById,
    createCategory,
    updateCategory,
    deleteCategory
}



